using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoApp
{
   class ToDoException : Exception
   {
      private string message;
      
      public ToDoException(string message_ = "Exception")
      {
         message = message_;
      }

      public string getMessage()
      {
         return message;
      }
   }
}
