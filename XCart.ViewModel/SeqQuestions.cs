using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;

namespace XCart.ViewModel
{
    public class SeqQuestions
    {
        public string[] getQuestions()
        {
            string[] que;
            que = new string[5]{"Which is your mobile company?", "What is your childhood nickname?", "What is the name of your first pet?"
                , "which was your first vehicle?", "which was your first mobile phone?" };
            return que;
        }
    }
}
