/*
 * Copyright 2019 Riccardo Paolo Bestetti
 * 
 * This file is part of Just Activate Windows.
 *
 * Just Activate Windows is free software: you can redistribute it and/or modify it under the terms of the
 * GNU General Public License as published by the Free Software Foundation, either version 3 of the License,
 * or (at your option) any later version.
 *
 * Just Activate Windows is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
 * even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General
 * Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Foobar.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jaw
{
    public partial class InputBox : Form
    {
        private int oldInputLength = 0;
        private bool ignoreTextChangedEvent = false;

        public string Input => productKeyBox.Text;
        public bool InputValid { get; private set; }

        public InputBox()
        {
            InitializeComponent();

            InputValid = false;

#if DEBUG
            TopMost = false;
#endif
        }

        // fancy shit straight outta '98 going on here
        // (yes, I know this is horrible, it looks dumb because it handles all
        // edge cases manually. if you can think of a better way, write, test and pr)
        private void ProductKeyBox_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChangedEvent)
            {
                ignoreTextChangedEvent = false;
                return;
            }

            string input = productKeyBox.Text;
            int selectionStart = productKeyBox.SelectionStart;

            bool isDeleting = false;
            if (input.Length < oldInputLength)
                isDeleting = true;

            oldInputLength = input.Length;

            input = input.ToUpper();

            string newInput = "";

            int chars = 0;
            foreach (char c in input)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
                {
                    chars++;
                    newInput += c;

                    if (chars % 5 == 0 && chars < 25)
                    {
                        newInput += '-';
                        selectionStart += 1;
                    }
                }
                else if (c == '-') selectionStart -= 1;

                if (chars == 25)
                    break;
            }

            if (!isDeleting)
            {
                if (newInput.Length < selectionStart)
                    selectionStart = newInput.Length;
            }
            else
            {
                if (newInput.Length < selectionStart)
                    selectionStart = newInput.Length;

                if (selectionStart != newInput.Length && newInput[newInput.Length - 1] == '-')
                    newInput = newInput.Substring(0, newInput.Length - 1);

                if (selectionStart > 0 && newInput[selectionStart - 1] == '-')
                {
                    selectionStart -= 1;
                    newInput = newInput.Substring(0, newInput.Length - 1);
                }
            }

            if (!input.Equals(newInput)) ignoreTextChangedEvent = true;
            productKeyBox.Text = newInput;
            productKeyBox.SelectionStart = selectionStart;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (productKeyBox.Text.Length == 29)
            {
                InputValid = true;
                Close();
            }
            else
                MessageBox.Show("Invalid key!", "Invalid key",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InputBox_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
