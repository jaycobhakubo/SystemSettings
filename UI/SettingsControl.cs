using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;

namespace GTI.Modules.SystemSettings.UI
{
	// This is the abstract base class for all of the settings panels
	public class SettingsControl : UserControl
	{
		public virtual bool LoadSettings() {return true; }
		public virtual bool SaveSettings() { return true; }
		public virtual bool IsModified() { return false; }
		public virtual void OnActivate(object o) {}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsControl));
			this.SuspendLayout();
			// 
			// SettingsControl
			// 

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			//this.DoubleBuffered = true;
			resources.ApplyResources(this, "$this");
			this.Name = "SettingsControl";
			this.ResumeLayout(false);

		}

     

		// The following routines were added to avoid Parse() frzom throwing exceptions for null values
		public bool ParseBool(string s)
		{
			// Try to parse the value
			bool result;
			bool default_value = false;
			if ( bool.TryParse( s, out result ))
			{
				return result;
			}
			else
			{
				return default_value;
			}
		}

		public DateTime ParseDateTime(string s)
		{
			// Try to parse the value
			DateTime result;
			DateTime default_value = DateTime.Now;
			if (DateTime.TryParse(s, out result))
			{
				return result;
			}
			else
			{
				return default_value;
			}
		}

		public int ParseInt(string s)
		{
			// Try to parse the value
			int result;
			int default_value = 1;
			if (int.TryParse(s, out result))
			{
				return result;
			}
			else
			{
				return default_value;
			}
		}

		public decimal ParseDecimal(string s)
		{
			// Try to parse the value
			decimal result;
			decimal default_value = 1;
			if (decimal.TryParse(s, out result))
			{
				return result;
			}
			else
			{
				return default_value;
			}
		}





	}

    /// Rally US4490
    /// <summary>
    /// Converts an enum value to it's [description] tag or returns the ToString equivilent
    /// </summary>
    public class EnumToString
    {
        /// <summary>
        /// returns the description of the enum value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(object value)
        {
            string output = value.ToString();

            try
            {
                // Get the enum type
                var enumVal = (Enum)value;
                var enumType = enumVal.GetType();

                // Get the description attribute
                var descriptionAttribute = enumType.GetField(enumVal.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute;

                // Get the description (if there is one) or the name of the
                // enum otherwise
                output = (descriptionAttribute != null ?
                    descriptionAttribute.Description : enumVal.ToString());

            }
            catch { }

            return output;
        }
    }
}
