using System;
using System.Collections.Generic;
using System.Text;

namespace BMIapp
{
    public class BMIResult
    {
        public int Id {  get; set; }
        public string Title {  get; set; }
        public DateTime Date {  get; set; }
        public float Weight {  get; set; }
        public float Height {  get; set; }
        public bool Gender {  get; set; }
        public int Score {  get; set; }
        public float BMI {  get; set; }
    }
}
