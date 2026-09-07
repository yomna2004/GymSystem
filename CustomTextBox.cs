using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSystem
{
    public partial class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        public bool IsRequired
        {
            get; set;
        }
        public enum InputTypeEnum {TextInput,NumberInput}
        public InputTypeEnum inputType
        {
            get; set;
        }= InputTypeEnum.TextInput;
        public bool IsNumeric()
        {
            string s = this.Text.Trim();
            foreach (char c in s)
            {
                if(!char.IsDigit(c) &&  c != '.')
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean IsVaild()
        {
            if(string.IsNullOrWhiteSpace(this.Text))
            {
                return !IsRequired;
            }
            
            if(inputType == InputTypeEnum.NumberInput)
            {
                return IsNumeric();
            }
            return true;
        }
    }
}
