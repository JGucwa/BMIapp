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
        public string Gender {  get; set; }
        public float BMI {  get; set; }
        public string Type {  get; set; }
    }
}
