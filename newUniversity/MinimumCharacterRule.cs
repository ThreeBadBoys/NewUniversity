﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace newUniversity
{
    public class MinimumCharacterRule : ValidationRule
    {
        public int MinimumCharacters { get; set; }
        public List<string> badchars = new List<string>();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string bad = "!@#$%^&*()_+=-.>/?<|~`\\";
            for (int i = 0; i < bad.Length; i++)
            {
                badchars.Add(Convert.ToString(bad[i]));
            }

            string charString = value as string;

            if (charString.Length < MinimumCharacters)
                return new ValidationResult(false, $"User atleast {MinimumCharacters} characters.");
            for (int i = 0; i < charString.Length; i++)
            {
                if (badchars.Contains(Convert.ToString(charString[i])))
                {
                    return new ValidationResult(false, "Invalid UserName");

                }
            }

            return new ValidationResult(true, null);
        }
    }
}
