using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SteamLauncher.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance;

		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("0")]
		[UserScopedSetting]
		public int LastLaunched
		{
			get
			{
				return (int)this["LastLaunched"];
			}
			set
			{
				this["LastLaunched"] = value;
			}
		}

		static Settings()
		{
			Settings.defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		}

		public Settings()
		{
		}
	}
}