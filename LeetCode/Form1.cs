using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeetCode
{
    public partial class Free : Form
    {
        public Free()
        {
            InitializeComponent();
            skinComboBox1.Items.Add("最长回文子串");
            skinComboBox1.Items.Add("整数反转");
            skinComboBox1.Items.Add("Z字形变换");
            skinComboBox1.Items.Add("划分数组为连续数字的集合");
            skinComboBox1.SelectedIndex = 0;
        }

        private void skinComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinComboBox1.Text == "最长回文子串")
            {
                string example = "babababac";
                textBox1.Text = example;
            }
            else if (skinComboBox1.Text == "整数反转")
            {
                string example = "123";
                textBox1.Text = example;
            }
            else if (skinComboBox1.Text == "Z字形变换")
            {
                string example = "FREEANDMEOW";
                textBox1.Text = example;
            }
            else if (skinComboBox1.Text == "划分数组为连续数字的集合")
            {
                int[] nums = new int[] { 1, 2, 3, 3, 4, 4, 5, 6 };
                string numsString = nums.ToString();
                textBox1.Text = numsString;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime dt1 = System.DateTime.Now;
            if (skinComboBox1.Text == "最长回文子串")
            {
                string _string = textBox1.Text;
                string result = Algorithm.Algorithm.Palindrome.LongestPalindrome(_string);
                textBox2.Text = result;
            }
            else if (skinComboBox1.Text == "整数反转")
            {
                int value = Convert.ToInt32(textBox1.Text);
                int result = Algorithm.Algorithm.Coverse.Reverse(value);
                textBox2.Text = Convert.ToString(result);
            }
            else if (skinComboBox1.Text == "Z字形变换")
            {
                string value = textBox1.Text;
                string result = Algorithm.Algorithm.ConvertZ.Convert(value, 3);
                textBox2.Text = result;
            }
            else if (skinComboBox1.Text == "划分数组为连续数字的集合")
            {

            }
            DateTime dt2 = System.DateTime.Now;
            TimeSpan ts = dt2.Subtract(dt1);
            textBox3.Text = ts.TotalMilliseconds.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (skinComboBox1.Text == "最长回文子串")
            {
                //string _string = getString(10);
                //textBox1.Text = _string;
            }
            else if (skinComboBox1.Text == "整数反转")
            { }
            else if (skinComboBox1.Text == "Z字形变换")
            { }
            else if (skinComboBox1.Text == "划分数组为连续数字的集合")
            { }
        }
        string getString(int count)
        {
            int number;
            string checkCode = String.Empty;     //存放随机码的字符串 

            System.Random random = new Random();

            for (int i = 0; i < count; i++) //产生4位校验码 
            {
                number = random.Next();
                number = number % 36;
                if (number < 10)
                {
                    number += 48;    //数字0-9编码在48-57 
                }
                else
                {
                    number += 55;    //字母A-Z编码在65-90 
                }

                checkCode += ((char)number).ToString();
            }
            return checkCode;
        }
    }
}
