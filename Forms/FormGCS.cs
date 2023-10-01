using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using GAPtest_Desktop.Services;
using GAPtest_Desktop.Models;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Drawing.Text;

namespace GAPtest_Desktop
{
    public partial class FormGCS : Form
    {
      
        public FormGCS(Users user)
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            tabControl2.SelectedIndexChanged += tabControl2_SelectedIndexChanged;
            userWithRole = user;
        }
        
        //SERVICES
        EmployeeService employeeService = new EmployeeService();
        ProductService productService = new ProductService(); 
        CategoryService categoryService = new CategoryService();
        ModelService modelService = new ModelService();
        OrderService orderService = new OrderService();
        CustomerService customerService = new CustomerService();
        SupplierService supplierService = new SupplierService();
        TitleService titleService = new TitleService();
        UserService userService = new UserService();
        UserRoleService userRoleService = new UserRoleService();
        LogErrorService logErrorService = new LogErrorService();

        //CONNECTION
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString);

        //VARIABLE TO ACCESS LOGGING USER'S INFORMATION
        public Users userWithRole; 

        private void FormGCS_Load(object sender, EventArgs e) //FORMLOAD
        {     
           
        }
        private void FormGCS_FormClosing(object sender, FormClosingEventArgs e) //APPLICATION EXIT
        {
            Application.Exit();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) //ACCESS TO TABS BY AUTHORIZATION AND FILL COMBOBOXES
        {
            TabPage selectedTabPage = tabControl1.SelectedTab;

            if (selectedTabPage == EmployeesTAB)
            {
                if (userWithRole.Employees == false)
                {
                    MessageBox.Show("YOU DO NOT HAVE PERMISSION");
                    tabControl1.SelectedTab = MainpageTAB;
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_PozisyonGetir", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    cbTitleEmployee.DataSource = dt;
                    cbTitleEmployee.DisplayMember = "Pozisyon";
                    cbTitleEmployee.ValueMember = "PozisyonID";
                    cbTitleEmployee.SelectedIndex = -1;
                    conn.Close();
                }
            }
            if (selectedTabPage == ProductsTAB)
            {
                if (userWithRole.Products == false)
                {
                    MessageBox.Show("YOU DO NOT HAVE PERMISSION");
                    tabControl1.SelectedTab = MainpageTAB;
                }               
                
            }
            if (selectedTabPage == OrdersTAB)
            {
                if (userWithRole.Orders == false)
                {
                    MessageBox.Show("YOU DO NOT HAVE PERMISSION");
                    tabControl1.SelectedTab = MainpageTAB;
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd4 = new SqlCommand("sp_CalisanGetir", conn);
                    cmd4.CommandType = CommandType.StoredProcedure;
                    DataTable dt4 = new DataTable();
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                    da4.Fill(dt4);
                    cbCalisanIDOrder.DataSource = dt4;
                    cbCalisanIDOrder.DisplayMember = "Ad";
                    cbCalisanIDOrder.ValueMember = "CalisanlarID";
                    cbCalisanIDOrder.SelectedIndex = -1;
                    conn.Close();

                    conn.Open();
                    SqlCommand cmd5 = new SqlCommand("sp_MusteriGetir", conn);
                    cmd5.CommandType = CommandType.StoredProcedure;
                    DataTable dt5 = new DataTable();
                    SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                    da5.Fill(dt5);
                    cbMusteriIDOrder.DataSource = dt5;
                    cbMusteriIDOrder.DisplayMember = "Ad";
                    cbMusteriIDOrder.ValueMember = "MusteriID";
                    cbMusteriIDOrder.SelectedIndex = -1;
                    conn.Close();

                    conn.Open();
                    SqlCommand cmd6 = new SqlCommand("sp_UrunGetir", conn);
                    cmd4.CommandType = CommandType.StoredProcedure;
                    DataTable dt6 = new DataTable();
                    SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
                    da6.Fill(dt6);
                    cbUrunIDOrder.DataSource = dt6;
                    cbUrunIDOrder.DisplayMember = "Urun";
                    cbUrunIDOrder.ValueMember = "UrunID";
                    cbUrunIDOrder.SelectedIndex = -1;
                    conn.Close();

                }
            }
            if (selectedTabPage == CustomersTAB)
            {
                if (userWithRole.Customers == false)
                {
                    MessageBox.Show("YOU DO NOT HAVE PERMISSION");
                    tabControl1.SelectedTab = MainpageTAB;
                }
            }
            if (selectedTabPage == SuppliersTAB)
            {
                if (userWithRole.Suppliers == false)
                {
                    MessageBox.Show("YOU DO NOT HAVE PERMISSION");
                    tabControl1.SelectedTab = MainpageTAB;
                }
            }
            if (selectedTabPage == TitlesTAB)
            {
                if (userWithRole.Titles == false)
                {
                    MessageBox.Show("YOU DO NOT HAVE PERMISSION");
                    tabControl1.SelectedTab = MainpageTAB;
                }
            }
            if (selectedTabPage == UsersTAB)
            {
                if (userWithRole.Userss == false)
                {
                    MessageBox.Show("YOU DO NOT HAVE PERMISSION");
                    tabControl1.SelectedTab = MainpageTAB;
                }
            }
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)//ACCESS TO TABS BY AUTHORIZATION AND FILL COMBOBOXES
        {
            TabPage selectedTabPage1 = tabControl2.SelectedTab;
            if (selectedTabPage1==ProductsTAB)
            {
                conn.Open();
                SqlCommand cmd4 = new SqlCommand("sp_ModelGetir", conn);
                cmd4.CommandType = CommandType.StoredProcedure;
                DataTable dt4 = new DataTable();
                SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                da4.Fill(dt4);
                cbModelProducts.DataSource = dt4;
                cbModelProducts.DisplayMember = "Model";
                cbModelProducts.ValueMember = "ModelID";
                cbModelProducts.SelectedIndex = -1;
                conn.Close();

                conn.Open();
                SqlCommand cmd5 = new SqlCommand("sp_TedarikciGetir", conn);
                cmd5.CommandType = CommandType.StoredProcedure;
                DataTable dt5 = new DataTable();
                SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                da5.Fill(dt5);
                cbSuppliersProduct.DataSource = dt5;
                cbSuppliersProduct.DisplayMember = "Tedarikci";
                cbSuppliersProduct.ValueMember = "TedarikciID";
                cbSuppliersProduct.SelectedIndex = -1;
                conn.Close();
            }
            if (selectedTabPage1==ModelTAB)
            {
                conn.Open();
                SqlCommand cmd5 = new SqlCommand("sp_KategoriGetir", conn);
                cmd5.CommandType = CommandType.StoredProcedure;
                DataTable dt5 = new DataTable();
                SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                da5.Fill(dt5);
                cbCategoryModel.DataSource = dt5;
                cbCategoryModel.DisplayMember = "Kategori";
                cbCategoryModel.ValueMember = "KategoriID";
                cbCategoryModel.SelectedIndex = -1;
                conn.Close();
            }
        } 


        ///////////////////////////////////////////////////EMPLOYEES//////////////////////////////////////////////////////////         
        void getEmployees()  //FUNCTION FOR SEARCH EMPLOYEE
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_CalisanGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewEMP.DataSource = dt;
            conn.Close();
            dataGridViewEMP.Columns["PozisyonID"].Visible = false;
            dataGridViewEMP.Columns["CalisanlarID"].Visible = false;
        } 
        void clearEmployee()   //FUNCTION FOR CLEAR EMPLOYEE
        {
            lblIDEmployee.Text = "";
            txtNameEmployee.Clear();
            txtSurnameEmployee.Clear();
            cbTitleEmployee.SelectedIndex = -1;
            dtDateEmployee.ResetText();
            txtSalaryEmployee.Clear();
            txtAddressEmployee.Clear();
            txtContactEmployee.Clear();
            rbMaleEmployee.Checked = false;
            rbFemaleEmployee.Checked = false;
            checkButtonEmployee();
        }        
        bool gender;  //DEFINING A VARIABLE FOR GENDER
        private void radioButton1_CheckedChanged(object sender, EventArgs e)  //FOR RADIOBUTTON
        {
            gender = true;
        }        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)  //FOR RADIOBUTTON
        {
            gender = false;
        }        
        void checkButtonEmployee()   //FUNCTION FOR BUTTON CHECK EMPLOYEE
        {
            if (lblIDEmployee.Text != "")
                btnInsertEmployee.Enabled = false;
            else if (lblIDEmployee.Text == "")
                    btnInsertEmployee.Enabled = true;
        }         
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)   //TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            if (e.RowIndex >= 0)
            {
                lblIDEmployee.Text = dataGridViewEMP.SelectedRows[0].Cells[0].Value.ToString();
                txtNameEmployee.Text = dataGridViewEMP.SelectedRows[0].Cells[1].Value.ToString();
                txtSurnameEmployee.Text = dataGridViewEMP.SelectedRows[0].Cells[2].Value.ToString();
                cbTitleEmployee.SelectedValue = dataGridViewEMP.SelectedRows[0].Cells[10].Value;
                dtDateEmployee.Text = dataGridViewEMP.SelectedRows[0].Cells[4].Value.ToString();
                txtSalaryEmployee.Text = dataGridViewEMP.SelectedRows[0].Cells[5].Value.ToString();
                txtAddressEmployee.Text = dataGridViewEMP.SelectedRows[0].Cells[6].Value.ToString();
                txtContactEmployee.Text = dataGridViewEMP.SelectedRows[0].Cells[7].Value.ToString();

                bool gender = Convert.ToBoolean(dataGridViewEMP.SelectedRows[0].Cells[8].Value);
                rbFemaleEmployee.Checked = gender == false ? true : false;
                rbMaleEmployee.Checked = gender == true ? true : false;
                checkButtonEmployee();
            }
        }         
        private void insertEmployee_Click(object sender, EventArgs e)  //INSERT
        {
            try
            {
                List<string> emptyFields = new List<string>();

                if (string.IsNullOrEmpty(txtNameEmployee.Text))
                    emptyFields.Add("NAME");

                if (string.IsNullOrEmpty(txtSurnameEmployee.Text))
                    emptyFields.Add("SURNAME");

                if (cbTitleEmployee.SelectedValue == null)
                    emptyFields.Add("TITLE");

                if (string.IsNullOrEmpty(txtSalaryEmployee.Text))
                    emptyFields.Add("SALARY");

                if (string.IsNullOrEmpty(txtContactEmployee.Text))
                    emptyFields.Add("CONTACT");

                if (string.IsNullOrEmpty(txtAddressEmployee.Text))
                    emptyFields.Add("ADDRESS");

                if ((rbMaleEmployee.Checked == false && rbFemaleEmployee.Checked == false))
                    emptyFields.Add("GENDER");

                if (emptyFields.Count > 0)
                {
                    string fields = string.Join(", ", emptyFields);
                    MessageBox.Show(fields + " Cannot be empty");
                    return;
                }
                

                Employees employee = new Employees();
                employee.Ad = txtNameEmployee.Text;
                employee.Soyad = txtSurnameEmployee.Text;
                employee.PozisyonID = Convert.ToInt32(cbTitleEmployee.SelectedValue);
                employee.BaslangıcTarih = dtDateEmployee.Value;
                employee.Maas = Convert.ToInt32(txtSalaryEmployee.Text);
                employee.Adres = txtAddressEmployee.Text;
                employee.Iletisim = txtContactEmployee.Text;
                employee.Cinsiyet = gender;
                employee.username = userWithRole.username;
                employeeService.InsertEmployee(employee);
                getEmployees();
                MessageBox.Show("Employee has been added");
                clearEmployee();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Employee INSERT "+ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }        
        private void updateEmployee_Click(object sender, EventArgs e)  //UPDATE
        {
            try
             {
                List<string> emptyFields = new List<string>();

                if (string.IsNullOrEmpty(txtNameEmployee.Text))
                    emptyFields.Add("NAME");

                if (string.IsNullOrEmpty(txtSurnameEmployee.Text))
                    emptyFields.Add("SURNAME");

                if (cbTitleEmployee.SelectedValue == null)
                    emptyFields.Add("TITLE");

                if (string.IsNullOrEmpty(txtSalaryEmployee.Text))
                    emptyFields.Add("SALARY");

                if (string.IsNullOrEmpty(txtContactEmployee.Text))
                    emptyFields.Add("CONTACT");

                if (string.IsNullOrEmpty(txtAddressEmployee.Text))
                    emptyFields.Add("ADDRESS");

                if ((rbMaleEmployee.Checked == false && rbFemaleEmployee.Checked == false))
                    emptyFields.Add("GENDER");

                if (emptyFields.Count > 0)
                {
                    string fields = string.Join(", ", emptyFields);
                    MessageBox.Show(fields + " Cannot be empty");
                    return;
                }
                Employees employee = new Employees();
                employee.CalisanlarID = Convert.ToInt32(lblIDEmployee.Text);
                employee.Ad = txtNameEmployee.Text;
                employee.Soyad = txtSurnameEmployee.Text;
                employee.PozisyonID = Convert.ToInt32(cbTitleEmployee.SelectedValue);
                employee.BaslangıcTarih = dtDateEmployee.Value;
                employee.Maas = Convert.ToInt32(txtSalaryEmployee.Text);
                employee.Adres = txtAddressEmployee.Text;
                employee.Iletisim = txtContactEmployee.Text;
                employee.Cinsiyet = gender;
                employee.username = userWithRole.username;
                employeeService.UpdateEmployee(employee);
                getEmployees();
                MessageBox.Show("Update is succesfully");
                clearEmployee();
            }
                catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Employee UPDATE "+ ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }  
        private void btnDeleteEmployee_Click(object sender, EventArgs e) //DELETE
        {
            try
            {
                if (lblIDEmployee.Text.Trim()=="")
                {
                    MessageBox.Show("YOU HAVE TO SELECT EMPLOYEE");
                    return;
                }
                Employees employee = new Employees();
                employee.CalisanlarID = Convert.ToInt32(lblIDEmployee.Text);
                employee.username = userWithRole.username;
                employeeService.DeleteEmployee(employee);
                getEmployees();
                MessageBox.Show("Employee has been deleted");
                clearEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Employee DELETE  " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }           
        }     
        private void searchEmployee_Click(object sender, EventArgs e)   //SEARCH
        {
            getEmployees();
        }      
        private void btnClearEmployee_Click(object sender, EventArgs e)   //CLEAR
        {
            clearEmployee();
        }      
        private void txtSalaryEmployee_KeyPress(object sender, KeyPressEventArgs e)//ONLY NUMBERS FOR SALARY-CONTACT TEXTBOXS
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtContactEmployee_KeyPress(object sender, KeyPressEventArgs e)//ONLY NUMBERS FOR SALARY-CONTACT TEXTBOXS
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }




        ///////////////////////////////////////////////////PRODUCTS/////////////////////////////////////////////////////////////////////
        void getProducts()//FUNCTION FOR SEARCH PRODUCT
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_UrunGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewPRD.DataSource = dt;
            conn.Close();
            dataGridViewPRD.Columns["ModelID"].Visible = false;
            dataGridViewPRD.Columns["UrunID"].Visible = false;
            dataGridViewPRD.Columns["TedarikciID"].Visible = false;
        } 
        void clearProducts() //FUNCTION FOR CLEAR PRODUCTS
        {
            lblProductIDProducts.Text = "";
            txtNameProducts.Clear();
            cbModelProducts.SelectedIndex = -1;
            txtPriceProducts.Clear();     
            txtStockProduct.Clear();
            cbSuppliersProduct.SelectedIndex = -1;
            checkButtonProduct();
        } 
        void checkButtonProduct() //FUNCTION FOR CHECK BUTTON PRODUCT
        {
            if (lblProductIDProducts.Text != "")
                btnInsertProducts.Enabled = false;
            else if (lblProductIDProducts.Text == "")
                btnInsertProducts.Enabled = true;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) // TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            if (e.RowIndex >= 0)
            {
                lblProductIDProducts.Text = dataGridViewPRD.SelectedRows[0].Cells[0].Value.ToString();
                txtNameProducts.Text = dataGridViewPRD.SelectedRows[0].Cells[1].Value.ToString();
                txtPriceProducts.Text = dataGridViewPRD.SelectedRows[0].Cells[3].Value.ToString();
                txtStockProduct.Text = dataGridViewPRD.SelectedRows[0].Cells[4].Value.ToString();
                cbModelProducts.SelectedValue = dataGridViewPRD.SelectedRows[0].Cells[6].Value;
                cbSuppliersProduct.SelectedValue = dataGridViewPRD.SelectedRows[0].Cells[7].Value;
                checkButtonProduct();
            }
        }
        private void btnInsertProducts_Click(object sender, EventArgs e)  //INSERT
        {
            try
            {
                List<string> emptyFields = new List<string>();

                if (string.IsNullOrEmpty(txtNameProducts.Text))
                    emptyFields.Add("NAME");

                if (cbModelProducts.SelectedValue == null)
                    emptyFields.Add("MODEL");

                if (string.IsNullOrEmpty(txtPriceProducts.Text))
                    emptyFields.Add("PRICE");

                if (string.IsNullOrEmpty(txtStockProduct.Text))
                    emptyFields.Add("STOCK COUNT");

                if (cbSuppliersProduct.SelectedValue == null)
                    emptyFields.Add("ADDRESS");             

                if (emptyFields.Count > 0)
                {
                    string fields = string.Join(", ", emptyFields);
                    MessageBox.Show(fields + " Cannot be empty");
                    return;
                }
                Products product = new Products();
                product.Urun = txtNameProducts.Text;
                product.ModelID = Convert.ToInt32(cbModelProducts.SelectedValue);
                product.Fiyat = Convert.ToInt32(txtPriceProducts.Text);
                product.StokSayısı = Convert.ToInt32(txtStockProduct.Text);
                product.TedarikciID = Convert.ToInt32(cbSuppliersProduct.SelectedValue);
                product.username = userWithRole.username;
                productService.InsertProduct(product);
                getProducts();              
                MessageBox.Show("Product has been added");
                clearProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Product INSERT " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
        private void btnUpdateProducts_Click(object sender, EventArgs e)  //UPDATE
        {
            try
            {
                List<string> emptyFields = new List<string>();

                if (string.IsNullOrEmpty(txtNameProducts.Text))
                    emptyFields.Add("NAME");

                if (cbModelProducts.SelectedValue == null)
                    emptyFields.Add("MODEL");

                if (string.IsNullOrEmpty(txtPriceProducts.Text))
                    emptyFields.Add("PRICE");

                if (string.IsNullOrEmpty(txtStockProduct.Text))
                    emptyFields.Add("STOCK COUNT");

                if (cbSuppliersProduct.SelectedValue == null)
                    emptyFields.Add("ADDRESS");

                if (emptyFields.Count > 0)
                {
                    string fields = string.Join(", ", emptyFields);
                    MessageBox.Show(fields + " Cannot be empty");
                    return;
                }
                Products product = new Products();
                product.UrunID = Convert.ToInt32(lblProductIDProducts.Text);
                product.Urun = txtNameProducts.Text;
                product.ModelID = Convert.ToInt32(cbModelProducts.SelectedValue);
                product.Fiyat = Convert.ToInt32(txtPriceProducts.Text);
                product.StokSayısı = Convert.ToInt32(txtStockProduct.Text);
                product.TedarikciID = Convert.ToInt32(cbSuppliersProduct.SelectedValue);
                product.username = userWithRole.username;
                productService.UpdateProduct(product);
                getProducts();
                MessageBox.Show("Update is succesfully");
                clearProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Product UPDATE " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
        private void btnDeleteProducts_Click(object sender, EventArgs e) //DELETE
        {
            try
            {
                if (lblProductIDProducts.Text.Trim()==" ")
                {
                    MessageBox.Show("YOU HAVE TO SELECT PRODUCT");
                }
                Products product = new Products();
                product.UrunID = Convert.ToInt32(lblProductIDProducts.Text);
                product.username = userWithRole.username;
                productService.DeleteProduct(product);
                getProducts() ;
                MessageBox.Show("Product has been deleted");
                clearProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Product DELETE " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
        private void btnSearchProducts_Click(object sender, EventArgs e)  //SEARCH
        {
            getProducts();
        }
        private void btnClearProducts_Click(object sender, EventArgs e)  //CLEAR
        {
            clearProducts();
        }
        private void txtPriceProducts_KeyPress(object sender, KeyPressEventArgs e) //ONLY NUMBERS FOR PRICE-STOCK TEXTBOXES
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtStockProduct_KeyPress(object sender, KeyPressEventArgs e)  //ONLY NUMBERS FOR PRICE-STOCK TEXTBOXES
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }




        ///////////////////////////////////////////////////MODEL-CATEGORY/////////////////////////////////////////////////////////////////////
        void getCategories() //FUNCTION FOR SEARCH CATEGORIES
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_KategoriGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewMDL.DataSource = dt;
            conn.Close();
            dataGridViewMDL.Columns["KategoriID"].Visible = false;
        }
        void clearCategories() //FUNCTION FOR CLEAR CATEGORIES
        {
            lblIDCategory.Text = "";
            txtNameCategory.Clear();
            checkButtonCategory();
        }
        void checkButtonCategory()  //FUNCTION FOR CHECK BUTTON CATEGORY
        {
            if (lblIDCategory.Text != "")
                btnInsertCategory.Enabled = false;
            else if (lblIDCategory.Text == "")
                btnInsertCategory.Enabled = true;
        }
        private void dataGridViewMC_CellContentClick(object sender, DataGridViewCellEventArgs e)  // TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            if (e.RowIndex >= 0)
            {
                lblIDCategory.Text = dataGridViewMDL.SelectedRows[0].Cells[0].Value.ToString();
                txtNameCategory.Text = dataGridViewMDL.SelectedRows[0].Cells[1].Value.ToString();  
                checkButtonCategory();
            }
        }
        private void btnInsertCategory_Click(object sender, EventArgs e) //INSERT
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameCategory.Text))                   
                {
                    MessageBox.Show("CATEGORY Cannot be empty");
                    return;
                }
                Categories category = new Categories();
                category.Kategori = txtNameCategory.Text;
                category.username = userWithRole.username;
                categoryService.InsertCategory(category);
                getCategories();
                MessageBox.Show("Categoru has been added");
                clearCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Category INSERT " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
        private void btnUpdateCategory_Click(object sender, EventArgs e) //UPDATE
        {
            try
            {
                if (string.IsNullOrEmpty(txtNameCategory.Text))               
                {
                    MessageBox.Show("CATEGORY Cannot be empty");
                    return;
                }
                Categories category = new Categories();
                category.KategoriID = Convert.ToInt32(lblIDCategory.Text);
                category.Kategori = txtNameCategory.Text;
                category.username = userWithRole.username;
                categoryService.UpdateCategory(category);
                getCategories();
                MessageBox.Show("Update is succesfully");
                clearCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Category UPDATE " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
        private void btnDeleteCategory_Click(object sender, EventArgs e) //DELETE
        {
            try
            {
                if (lblIDCategory.Text.Trim() == " ")
                {
                    MessageBox.Show("YOU HAVE TO SELECT CATEGORY");
                }
                Categories category = new Categories();
                category.KategoriID = Convert.ToInt32(lblIDCategory.Text);
                category.username = userWithRole.username;
                categoryService.DeleteCategory(category);
                getCategories();
                MessageBox.Show("Category has been deleted");
                clearCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Category DELETE " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }          
        }
        private void btnSearchCategory_Click(object sender, EventArgs e) //SEARCH
        {
            getCategories();
        }
        private void btnClearCategory_Click(object sender, EventArgs e) //CLEAR
        {
            clearCategories();
        }


        void getModels()//FUNCTION FOR SEARCH MODELS
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_ModelGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewMDLC.DataSource = dt;
            conn.Close();
            dataGridViewMDLC.Columns["ModelID"].Visible = false;
            dataGridViewMDLC.Columns["KategoriID"].Visible = false;
        }
        void clearModels() //FUNCTION FOR CLEAR MODELS
        {
            lblIDModel.Text = "";
            txtNameModel.Clear();
            cbCategoryModel.SelectedIndex = -1;
            checkButtonModel();
        }
        void checkButtonModel() //FUNCTION FOR CHECK BUTTON MODEL
        {
            if (lblIDModel.Text != "")
                btnInsertModel.Enabled = false;
            else if (lblIDModel.Text == "")
                btnInsertModel.Enabled = true;
        }
        private void dataGridViewMDLC_CellContentClick_1(object sender, DataGridViewCellEventArgs e) //TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            if (e.RowIndex >= 0)
            {
                lblIDModel.Text = dataGridViewMDLC.SelectedRows[0].Cells[0].Value.ToString();
                txtNameModel.Text = dataGridViewMDLC.SelectedRows[0].Cells[1].Value.ToString();
                cbCategoryModel.SelectedValue = dataGridViewMDLC.SelectedRows[0].Cells[2].Value;
                checkButtonModel();
            }
        }
        private void btnInsertModel_Click_1(object sender, EventArgs e) //INSERT
        {
            try
            {
                List<string> emptyFields = new List<string>();

                if (string.IsNullOrEmpty(txtNameModel.Text))
                    emptyFields.Add("NAME");

                if (cbCategoryModel.SelectedValue == null)
                    emptyFields.Add("CATEGORY");

                if (emptyFields.Count > 0)
                {
                    string fields = string.Join(", ", emptyFields);
                    MessageBox.Show(fields + " Cannot be empty");
                    return;
                }
                Modelss model = new Modelss();
                model.Model = txtNameModel.Text;
                model.KategoriID = Convert.ToInt32(cbCategoryModel.SelectedValue);
                model.username = userWithRole.username;
                modelService.InsertModel(model);
                getModels();
                MessageBox.Show("Model has been added");
                clearModels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Model INSERT " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
        private void btnUpdateModel_Click_1(object sender, EventArgs e) //UPDATE
        {
            try
            {
                List<string> emptyFields = new List<string>();

                if (string.IsNullOrEmpty(txtNameModel.Text))
                    emptyFields.Add("NAME");

                if (cbCategoryModel.SelectedValue == null)
                    emptyFields.Add("CATEGORY");

                if (emptyFields.Count > 0)
                {
                    string fields = string.Join(", ", emptyFields);
                    MessageBox.Show(fields + " Cannot be empty");
                    return;
                }
                Modelss model = new Modelss();
                model.ModelID = Convert.ToInt32(lblIDModel.Text);
                model.Model = txtNameModel.Text;
                model.KategoriID = Convert.ToInt32(cbCategoryModel.SelectedValue);
                model.username = userWithRole.username;
                modelService.UpdateModel(model);
                getModels();
                MessageBox.Show("Update is succesfully");
                clearModels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Model UPDATE " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
        private void btnDeleteModel_Click_1(object sender, EventArgs e) //DELETE
        {
            try
            {
                if (lblIDModel.Text.Trim() == " ")
                {
                    MessageBox.Show("YOU HAVE TO SELECT MODEL");
                    return;
                }
                Modelss model = new Modelss();
                model.ModelID = Convert.ToInt32(lblIDModel.Text);
                model.username = userWithRole.username;
                modelService.DeleteModel(model);
                getModels();
                MessageBox.Show("Model has been deleted");
                clearModels();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Model DELETE " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
        }
        private void btnSearchModel_Click_1(object sender, EventArgs e) //SEARCH
        {
            getModels();
        }
        private void btnClearModel_Click(object sender, EventArgs e)  //CLEAR
        {
            clearModels();
        }



        ///////////////////////////////////////////////////ORDERS/////////////////////////////////////////////////////////////////////
        void getOrders()//FUNCTION FOR SEARCH ORDERS
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_SiparisGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewORD.DataSource = dt;
            conn.Close();
            dataGridViewORD.Columns["CalisanID"].Visible = false;
            dataGridViewORD.Columns["MusteriID"].Visible = false;
            dataGridViewORD.Columns["UrunID"].Visible = false;
        }
        void clearOrders() //FUNCTION FOR CLEAR ORDERS
        {
            lblIDOrder.Text = "";
            cbCalisanIDOrder.SelectedIndex = -1;
            cbMusteriIDOrder.SelectedIndex = -1;
            cbUrunIDOrder.SelectedIndex = -1;
            checkButtonOrder();
        }
        void checkButtonOrder() //FUNCTION FOR CHECK BUTTON ORDER
        {
            if (lblIDOrder.Text != "")
                btnInsertOrder.Enabled = false;
            else if (lblIDOrder.Text == "")
                btnInsertOrder.Enabled = true;
        }
        private void dataGridViewORD_CellContentClick(object sender, DataGridViewCellEventArgs e) //TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            if (e.RowIndex >= 0)
            {
                lblIDOrder.Text = dataGridViewORD.SelectedRows[0].Cells[0].Value.ToString();
                cbCalisanIDOrder.SelectedValue = dataGridViewORD.SelectedRows[0].Cells[4].Value;
                cbMusteriIDOrder.SelectedValue = dataGridViewORD.SelectedRows[0].Cells[5].Value;
                cbUrunIDOrder.SelectedValue = dataGridViewORD.SelectedRows[0].Cells[6].Value;
                checkButtonOrder();
            }
        }
        private void btnInsertOrder_Click(object sender, EventArgs e)  //INSERT
        {

            {
                try
                {
                    List<string> emptyFields = new List<string>();

                    if (cbCalisanIDOrder.SelectedValue==null)
                        emptyFields.Add("EMPLOYEE");

                    if (cbMusteriIDOrder.SelectedValue == null)
                        emptyFields.Add("CUSTOMER");

                    if (cbUrunIDOrder.SelectedValue == null)
                        emptyFields.Add("PRODUCT");

                    if (emptyFields.Count > 0)
                    {
                        string fields = string.Join(", ", emptyFields);
                        MessageBox.Show(fields + " Cannot be empty");
                        return;
                    }
                    Orders order = new Orders();                  
                    order.CalisanID = Convert.ToInt32(cbCalisanIDOrder.SelectedValue);
                    order.MusteriID = Convert.ToInt32(cbMusteriIDOrder.SelectedValue);
                    order.UrunID = Convert.ToInt32(cbUrunIDOrder.SelectedValue);
                    order.username = userWithRole.username;
                    orderService.InsertOrder(order);
                    getOrders();
                    MessageBox.Show("Order has been added");
                    clearOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Order INSERT " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnUpdateOrder_Click(object sender, EventArgs e)  //UPDATE
        {

            {
                try
                {
                    List<string> emptyFields = new List<string>();

                    if (cbCalisanIDOrder.SelectedValue == null)
                        emptyFields.Add("EMPLOYEE");

                    if (cbMusteriIDOrder.SelectedValue == null)
                        emptyFields.Add("CUSTOMER");

                    if (cbUrunIDOrder.SelectedValue == null)
                        emptyFields.Add("PRODUCT");

                    if (emptyFields.Count > 0)
                    {
                        string fields = string.Join(", ", emptyFields);
                        MessageBox.Show(fields + " Cannot be empty");
                        return;
                    }
                    Orders order = new Orders();                 
                    order.CalisanID = Convert.ToInt32(cbCalisanIDOrder.SelectedValue);
                    order.MusteriID = Convert.ToInt32(cbMusteriIDOrder.SelectedValue);
                    order.UrunID = Convert.ToInt32(cbUrunIDOrder.SelectedValue);
                    order.username = userWithRole.username;
                    orderService.UpdateOrder(order);
                    getOrders();
                    MessageBox.Show("Update is succesfully");
                    clearOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Order UPDATE " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnDeleteOrder_Click(object sender, EventArgs e)  //DELETE
        {

            {
                try
                {
                    if (lblIDOrder.Text.Trim() == " ")
                    {
                        MessageBox.Show("YOU HAVE TO SELECT ORDER");
                        return;
                    }
                    Orders order = new Orders();
                    order.SiparisID = Convert.ToInt32(lblIDOrder.Text);
                    order.username = userWithRole.username;
                    orderService.DeleteOrder(order);
                    getOrders();
                    MessageBox.Show("Order has been deleted");
                    clearOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Order DELETE " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnSearchOrder_Click(object sender, EventArgs e)  //SEARCH
        {
            getOrders();
        }
        private void btnClearOrder_Click(object sender, EventArgs e)  //CLEAR
        {
            clearOrders();
        }



        ///////////////////////////////////////////////////CUSTOMERS/////////////////////////////////////////////////////////////////////
        void getCustomers()  //FUNCTION FOR SEARCH CUSTOMERS
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_MusteriGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCMR.DataSource = dt;
            conn.Close();
            dataGridViewCMR.Columns["MusteriID"].Visible = false;
        }
        void clearCustomers()   //FUNCTION FOR CLEAR CUSTOMERS
        {
            lblCustomerID.Text = "";
            txtNameCustomer.Clear();
            txtSurnameCustomer.Clear();
            txtContactCustomer.Clear();
            txtAddressCustomer.Clear();
            rbMaleCustomer.Checked = false;
            rbFemaleCustomer.Checked = false;
            checkButtonCustomer();
        }
        bool gender1;  //DEFINING A VARIABLE FOR GENDER
        private void rbMaleCustomer_CheckedChanged(object sender, EventArgs e) //FOR RADIOBUTTON
        {
            gender1 = true;
        }
        private void rbFemaleCustomer_CheckedChanged(object sender, EventArgs e) //FOR RADIOBUTTON
        {
            gender1 = false;
        }
        void checkButtonCustomer()   //FUNCTION FOR BUTTON CHECK CUSTOMER
        {
            if (lblCustomerID.Text != "")
                btnInsertCustomer.Enabled = false;
            else if (lblCustomerID.Text == "")
                btnInsertCustomer.Enabled = true;
        }
        private void dataGridViewCMR_CellContentClick(object sender, DataGridViewCellEventArgs e) //TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            if (e.RowIndex >= 0)
            {
                lblCustomerID.Text = dataGridViewCMR.SelectedRows[0].Cells[0].Value.ToString();
                txtNameCustomer.Text = dataGridViewCMR.SelectedRows[0].Cells[1].Value.ToString();
                txtSurnameCustomer.Text = dataGridViewCMR.SelectedRows[0].Cells[2].Value.ToString();
                txtContactCustomer.Text = dataGridViewCMR.SelectedRows[0].Cells[3].Value.ToString();
                txtAddressCustomer.Text = dataGridViewCMR.SelectedRows[0].Cells[5].Value.ToString();

                bool gender1 = Convert.ToBoolean(dataGridViewCMR.SelectedRows[0].Cells[4].Value);
                rbFemaleCustomer.Checked = gender == false ? true : false;
                rbMaleCustomer.Checked = gender == true ? true : false;
                checkButtonCustomer();
            }
        }
        private void btnInsertCustomer_Click(object sender, EventArgs e)  //INSERT
        {

            {
                try
                {
                    List<string> emptyFields = new List<string>();

                    if (string.IsNullOrEmpty(txtNameCustomer.Text))
                        emptyFields.Add("NAME");

                    if (string.IsNullOrEmpty(txtSurnameCustomer.Text))
                        emptyFields.Add("SURNAME");
                 
                    if (string.IsNullOrEmpty(txtContactCustomer.Text))
                        emptyFields.Add("CONTACT");

                    if (string.IsNullOrEmpty(txtAddressCustomer.Text))
                        emptyFields.Add("ADDRESS");

                    if ((rbMaleCustomer.Checked == false && rbFemaleCustomer.Checked == false))
                        emptyFields.Add("GENDER");

                    if (emptyFields.Count > 0)
                    {
                        string fields = string.Join(", ", emptyFields);
                        MessageBox.Show(fields + " Cannot be empty");
                        return;
                    }
                    Customers customer = new Customers();
                    customer.Ad = txtNameCustomer.Text;
                    customer.Soyad = txtSurnameCustomer.Text;
                    customer.Iletisim = txtContactCustomer.Text;
                    customer.Cinsiyet = gender1;
                    customer.Adres = txtAddressCustomer.Text;
                    customer.username = userWithRole.username;
                    customerService.InsertCustomer(customer);
                    getCustomers();
                    MessageBox.Show("Customer has been added");
                    clearCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Customer INSERT " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnUpdateCustomer_Click(object sender, EventArgs e)  //UPDATE
        {

            {
                try
                {
                    List<string> emptyFields = new List<string>();

                    if (string.IsNullOrEmpty(txtNameCustomer.Text))
                        emptyFields.Add("NAME");

                    if (string.IsNullOrEmpty(txtSurnameCustomer.Text))
                        emptyFields.Add("SURNAME");

                    if (string.IsNullOrEmpty(txtContactCustomer.Text))
                        emptyFields.Add("CONTACT");

                    if (string.IsNullOrEmpty(txtAddressCustomer.Text))
                        emptyFields.Add("ADDRESS");

                    if ((rbMaleCustomer.Checked == false && rbFemaleCustomer.Checked == false))
                        emptyFields.Add("GENDER");

                    if (emptyFields.Count > 0)
                    {
                        string fields = string.Join(", ", emptyFields);
                        MessageBox.Show(fields + " Cannot be empty");
                        return;
                    }
                    Customers customer = new Customers();
                    customer.MusteriID = Convert.ToInt32(lblCustomerID.Text);
                    customer.Ad = txtNameCustomer.Text;
                    customer.Soyad = txtSurnameCustomer.Text;
                    customer.Iletisim = txtContactCustomer.Text;
                    customer.Cinsiyet = gender1;
                    customer.Adres = txtAddressCustomer.Text;
                    customer.username = userWithRole.username;
                    customerService.UpdateCustomer(customer);
                    getCustomers();
                    MessageBox.Show("Update is succesfully");
                    clearCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Customer UPDATE " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)  //DELETE
        {
            {
                try
                {
                    if (lblCustomerID.Text.Trim()=="")
                    {
                        MessageBox.Show("YOU HAVE TO SELECT CUSTOMER");
                        return;
                    }
                    Customers customer = new Customers();
                    customer.MusteriID = Convert.ToInt32(lblCustomerID.Text);
                    customer.username = userWithRole.username;
                    customerService.DeleteCustomer(customer);
                    getCustomers();
                    MessageBox.Show("Customer has been deleted");
                    clearCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Customer DELETE " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnSearchCustomer_Click(object sender, EventArgs e)  //SEARCH
        {
            getCustomers();
        }
        private void btnClearCustomer_Click(object sender, EventArgs e)  //CLEAR
        {
            clearCustomers() ;
        }
        private void txtContactCustomer_KeyPress(object sender, KeyPressEventArgs e) ////ONLY NUMBERS FOR CONTACT TEXTBOX
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }



        ///////////////////////////////////////////////////SUPPLIERS/////////////////////////////////////////////////////////////////////   
        void getSuppliers() //FUNCTION FOR SEARCH SUPPLIERS
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_TedarikciGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewSUP.DataSource = dt;
            conn.Close();
            dataGridViewSUP.Columns["TedarikciID"].Visible = false;
        }
        void clearSuppliers() //FUNCTION FOR CLEAR SUPPLIERS
        {
            lblSuppliersID.Text = "";
            txtNameSuppliers.Clear();
            checkButtonSupplier();
        }
        void checkButtonSupplier()  //FUNCTION FOR CHECK BUTTON SUPPLIER
        {
            if (lblSuppliersID.Text != "")
                btnInsertSuppliers.Enabled = false;
            else if (lblSuppliersID.Text == "")
                btnInsertSuppliers.Enabled = true;
        }
        private void dataGridViewSUP_CellContentClick(object sender, DataGridViewCellEventArgs e) //TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            if (e.RowIndex >= 0)
            {
                lblSuppliersID.Text = dataGridViewSUP.SelectedRows[0].Cells[0].Value.ToString();
                txtNameSuppliers.Text = dataGridViewSUP.SelectedRows[0].Cells[1].Value.ToString();
                checkButtonSupplier();
            }
        }
        private void btnInsertSuppliers_Click(object sender, EventArgs e) //INSERT
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(txtNameSuppliers.Text))
                    {
                        MessageBox.Show(" NAME Cannot be empty");
                        return;
                    }
                    Suppliers suppliers = new Suppliers();
                    suppliers.Tedarikci = txtNameSuppliers.Text;
                    suppliers.username = userWithRole.username;
                    supplierService.InsertSupplier(suppliers);
                    getSuppliers();
                    MessageBox.Show("Supplier has been added");
                    clearSuppliers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Supplier INSERT " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnUpdateSuppliers_Click(object sender, EventArgs e) //UPDATE
        {
            {
                try
                {
                    if (string.IsNullOrEmpty(txtNameSuppliers.Text))
                    {
                        MessageBox.Show("NAME Cannot be empty");
                        return;
                    }
                    Suppliers suppliers = new Suppliers();
                    suppliers.TedarikciID = Convert.ToInt32(lblSuppliersID.Text);
                    suppliers.Tedarikci = txtNameSuppliers.Text;
                    suppliers.username = userWithRole.username;
                    supplierService.UpdateSupplier(suppliers);
                    getSuppliers();
                    MessageBox.Show("Update is succesfully");
                    clearSuppliers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Supplier UPDATE " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnDeleteSuppliers_Click(object sender, EventArgs e)  //DELETE
        {
            {
                try
                {
                    if (lblSuppliersID.Text.Trim() == " ")
                    {
                        MessageBox.Show("YOU HAVE TO SELECT SUPPLIER");
                        return;
                    }
                    Suppliers suppliers = new Suppliers();
                    suppliers.TedarikciID = Convert.ToInt32(lblSuppliersID.Text);
                    suppliers.username = userWithRole.username;
                    supplierService.DeleteSupplier(suppliers);
                    getSuppliers();
                    MessageBox.Show("Supplier has been deleted");
                    clearSuppliers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "Supplier DELETE " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnSearchSuppliers_Click(object sender, EventArgs e)  //SEARCH
        {
            getSuppliers();
        }
        private void btnClearSuppliers_Click(object sender, EventArgs e)  //CLEAR
        {
            clearSuppliers();
        }



        ///////////////////////////////////////////////////TITLES/////////////////////////////////////////////////////////////////////
        void getTitles() //FUNCTION FOR SEARCH TITLES
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_PozisyonGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewTT.DataSource = dt;
            conn.Close();
            dataGridViewTT.Columns["PozisyonID"].Visible = false;
        }
        void clearTitles() //FUNCTION FOR CLEAR TITLES
        {
            lblTitleID.Text = "";
            txtNameTitle.Clear();
            checkButtonTitle();
        }
        void checkButtonTitle()  //FUNCTION FOR CHECK BUTTON SUPPLIER
        {
            if (lblTitleID.Text != "")
                btnInsertTitle.Enabled = false;
            else if (lblTitleID.Text == "")
                btnInsertTitle.Enabled = true;
        }
        private void dataGridViewTT_CellContentClick(object sender, DataGridViewCellEventArgs e) // TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            {
                if (e.RowIndex >= 0)
                {
                    lblTitleID.Text = dataGridViewTT.SelectedRows[0].Cells[0].Value.ToString();
                    txtNameTitle.Text = dataGridViewTT.SelectedRows[0].Cells[1].Value.ToString();
                    checkButtonTitle();
                }
            }
        }
        private void btnInsertTitle_Click(object sender, EventArgs e) //INSERT
        {
            {
                {
                    try
                    {
                        if (string.IsNullOrEmpty(txtNameTitle.Text))
                        {
                            MessageBox.Show("NAME Cannot be empty");
                            return;
                        }
                        Titles title = new Titles();
                        title.Pozisyon = txtNameTitle.Text;
                        title.username = userWithRole.username;
                        titleService.InsertTitle(title);
                        getTitles();
                        MessageBox.Show("Title has been added");
                        clearTitles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred");
                        LogError log = new LogError();
                        log.Log = "Title INSERT " + ex.Message.ToString();
                        logErrorService.InsertLog(log);
                    }
                }
            }
        }
        private void btnUpdateTitle_Click(object sender, EventArgs e) //UPDATE
        {
            {
                {
                    try
                    {
                        if (string.IsNullOrEmpty(txtNameTitle.Text))
                        {
                            MessageBox.Show("NAME Cannot be empty");
                            return;
                        }
                        Titles title = new Titles();
                        title.PozisyonID = Convert.ToInt32(lblTitleID.Text);
                        title.Pozisyon = txtNameTitle.Text;
                        title.username = userWithRole.username;
                        titleService.UpdateTitle(title);
                        getTitles();
                        MessageBox.Show("Update is succesfully");
                        clearTitles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred");
                        LogError log = new LogError();
                        log.Log = "Title UPDATE " + ex.Message.ToString();
                        logErrorService.InsertLog(log);
                    }
                }
            }
        }
        private void btnDeleteTitle_Click(object sender, EventArgs e) //DELETE
        {
            {
                {
                    try
                    {
                        if (lblTitleID.Text.Trim() == " ")
                        {
                            MessageBox.Show("YOU HAVE TO SELECT TITLE");
                            return;
                        }
                        Titles title = new Titles();
                        title.PozisyonID = Convert.ToInt32(lblTitleID.Text);
                        title.username = userWithRole.username;
                        titleService.DeleteTitle(title);
                        getTitles();
                        MessageBox.Show("Title has been deleted");
                        clearTitles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred");
                        LogError log = new LogError();
                        log.Log = "Title DELETE " + ex.Message.ToString();
                        logErrorService.InsertLog(log);
                    }
                }
            }
        }
        private void btnSearchTitle_Click(object sender, EventArgs e) //SEARCH
        {
            getTitles();
        }
        private void btnClearTitle_Click(object sender, EventArgs e) //CLEAR
        {
            clearTitles();
        }



        ///////////////////////////////////////////////////USERS/////////////////////////////////////////////////////////////////////
        void getUsers()//FUNCTION FOR SEARCH USERS
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_KullaniciGetir", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewUSR.DataSource = dt;
            conn.Close();
            dataGridViewUSR.Columns["KullaniciID"].Visible = false;          
        }
        void clearUsers() //FUNCTION FOR CLEAR USERS
        {
            lblIDUsers.Text = "";
            txtNameUsers.Clear();
            txtPwUsers.Clear();
            chbEMP.Checked = false;
            chbPRD.Checked = false;
            chbOrders.Checked = false;
            chbCST.Checked = false;   
            chbSuppliers.Checked = false;
            chbTitles.Checked = false;
            chbUSR.Checked = false;
            chbActive.Checked = false;
            txtQuestionUser.Clear();
            checkButtonUser();
        }
        void checkButtonUser() //FUNCTION FOR CHECK BUTTON USER
        {
            if (lblIDUsers.Text != "")
                btnInsertUsers.Enabled = false;
            else if (lblIDUsers.Text == "")
                btnInsertUsers.Enabled = true;
        }
        private void dataGridViewUSR_CellContentClick(object sender, DataGridViewCellEventArgs e) //TO FILL COLUMNS FROM DATAGRIDVIEW
        {
            {
                if (e.RowIndex >= 0)
                {
                    lblIDUsers.Text = dataGridViewUSR.SelectedRows[0].Cells[0].Value.ToString();
                    txtNameUsers.Text = dataGridViewUSR.SelectedRows[0].Cells[1].Value.ToString();
                    txtPwUsers.Text = dataGridViewUSR.SelectedRows[0].Cells[2].Value.ToString();
                    chbEMP.Checked = Convert.ToBoolean(dataGridViewUSR.SelectedRows[0].Cells[3].Value);
                    chbPRD.Checked = Convert.ToBoolean(dataGridViewUSR.SelectedRows[0].Cells[4].Value);
                    chbOrders.Checked = Convert.ToBoolean(dataGridViewUSR.SelectedRows[0].Cells[5].Value);
                    chbCST.Checked = Convert.ToBoolean(dataGridViewUSR.SelectedRows[0].Cells[6].Value);
                    chbSuppliers.Checked = Convert.ToBoolean(dataGridViewUSR.SelectedRows[0].Cells[7].Value);
                    chbTitles.Checked = Convert.ToBoolean(dataGridViewUSR.SelectedRows[0].Cells[8].Value);
                    chbUSR.Checked = Convert.ToBoolean(dataGridViewUSR.SelectedRows[0].Cells[9].Value);
                    chbActive.Checked = Convert.ToBoolean(dataGridViewUSR.SelectedRows[0].Cells[9].Value);
                    txtQuestionUser.Text = dataGridViewUSR.SelectedRows[0].Cells[10].Value.ToString();
                    checkButtonUser();
                }
            }
        }
        private void btnInsertUsers_Click(object sender, EventArgs e) //INSERT
        {
            {
                try
                {
                    List<string> emptyFields = new List<string>();

                    if (string.IsNullOrEmpty(txtNameUsers.Text))
                        emptyFields.Add("USERNAME");

                    if (string.IsNullOrEmpty(txtPwUsers.Text))
                        emptyFields.Add("PASSWORD");

                    if (string.IsNullOrEmpty(txtQuestionUser.Text))
                        emptyFields.Add("QUESTION");

                    if (emptyFields.Count > 0)
                    {
                        string fields = string.Join(", ", emptyFields);
                        MessageBox.Show(fields + " Cannot be empty");
                        return;
                    }
                    Users user = new Users();
                    user.username = txtNameUsers.Text;
                    user.pw = txtPwUsers.Text;
                    user.Employees = chbEMP.Checked;
                    user.Products = chbPRD.Checked;
                    user.Orders = chbOrders.Checked;
                    user.Customers = chbCST.Checked;
                    user.Suppliers = chbEMP.Checked;
                    user.Titles = chbTitles.Checked;
                    user.Userss = chbUSR.Checked;
                    user.Question = txtQuestionUser.Text;
                    user.IsActive = chbActive.Checked;
                    user.username1 = userWithRole.username;
                    userService.InsertUser(user);
                    getUsers();
                    MessageBox.Show("User has been added");
                    clearUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "User INSERT " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnUpdateUsers_Click(object sender, EventArgs e) //UPDATE
        {
            {
                try
                {
                    List<string> emptyFields = new List<string>();

                    if (string.IsNullOrEmpty(txtNameUsers.Text))
                        emptyFields.Add("USERNAME");

                    if (string.IsNullOrEmpty(txtPwUsers.Text))
                        emptyFields.Add("PASSWORD");

                    if (string.IsNullOrEmpty(txtQuestionUser.Text))
                        emptyFields.Add("QUESTION");

                    if (emptyFields.Count > 0)
                    {
                        string fields = string.Join(", ", emptyFields);
                        MessageBox.Show(fields + " Cannot be empty");
                        return;
                    }
                    Users user = new Users();
                    user.KullaniciID = Convert.ToInt32(lblIDUsers.Text);
                    user.username = txtNameUsers.Text;
                    user.pw = txtPwUsers.Text;
                    user.Employees = chbEMP.Checked;
                    user.Products = chbPRD.Checked;
                    user.Orders = chbOrders.Checked;
                    user.Customers = chbCST.Checked;
                    user.Suppliers = chbSuppliers.Checked;
                    user.Titles = chbTitles.Checked;
                    user.Userss = chbUSR.Checked;
                    user.Question = txtQuestionUser.Text;
                    user.IsActive = chbActive.Checked;
                    user.username1 = userWithRole.username;
                    userService.UpdateUser(user);
                    getUsers();
                    MessageBox.Show("Update is succesfully");
                    clearUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "User UPDATE " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnDeleteUsers_Click(object sender, EventArgs e) //DELETE
        {
            {
                try
                {
                    if (lblIDUsers.Text.Trim() == " ")
                    {
                        MessageBox.Show("YOU HAVE TO SELECT USER");
                        return;
                    }
                    Users user = new Users();
                    user.KullaniciID = Convert.ToInt32(lblIDUsers.Text);
                    user.username1 = userWithRole.username;
                    userService.DeleteUser(user);
                    getUsers();
                    MessageBox.Show("User has been deleted");
                    clearUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error has occurred");
                    LogError log = new LogError();
                    log.Log = "User DELETE " + ex.Message.ToString();
                    logErrorService.InsertLog(log);
                }
            }
        }
        private void btnSearchUsers_Click(object sender, EventArgs e) //SEARCH
        {
            getUsers();
        }
        private void btnClearUsers_Click(object sender, EventArgs e) //CLEAR
        {
            clearUsers();
        }
    }
}

