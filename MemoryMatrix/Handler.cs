using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MemoryMatrix
{
    class Handler
    {
        public static void closeLoginForm(String userName, Form form)
        {
            form.Text = $"Главное меню [{userName}]";
        }

        
    }
}
