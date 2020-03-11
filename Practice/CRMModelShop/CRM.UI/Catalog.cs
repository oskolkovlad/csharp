using System.Data.Entity;
using System.Windows.Forms;
using CRM.BL.Model;

namespace CRM.UI
{
    public partial class Catalog<TEntity> : Form
        where TEntity: class
    {
        public Catalog()
        {
            InitializeComponent();
        }

        public Catalog(DbSet<TEntity> dbSet)
        {
            InitializeComponent();

            dataGridView.DataSource = dbSet.Local.ToBindingList();
        }
    }
}
