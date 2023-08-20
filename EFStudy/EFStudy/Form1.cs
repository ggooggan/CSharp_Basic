using EFStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace EFStudy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new EFDBContext())
            {
                //기존 DB가 존재할 경우 삭제
                bool deleted = context.Database.EnsureDeleted();

                //Model로 부터 DB를 만들고 필요한 SQL Script를 생성
                bool created = context.Database.EnsureCreated();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new EFDBContext())
            {
            }
        }
    }
}