namespace Tefter
{
    using System.Windows.Forms;

    public partial class SearchAllNotesForm : Form
    {
        private readonly ApplicationDbContext dbContext;

        public SearchAllNotesForm(ApplicationDbContext dbContext)
        {
            InitializeComponent();

            this.dbContext = dbContext;
        }
    }
}
