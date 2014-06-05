using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Wpf.Controls;
using System.Windows.Controls.Primitives;
using System.Data;
using System.Windows.Input;

namespace WMS_Project_TM_Store_IT
{
    /// <summary>
    /// Interaction logic for UserFrame.xaml
    /// </summary>
    public partial class UserFrame : Window
    {
        #region Field
        private Wpf.Controls.TabControl.Section SectionSelected = Wpf.Controls.TabControl.Section.DEFAULT;

        //Inventory table
        private INV_Query InvQuery;
        private bool needTableFresh = false;
        private AttributesEditOption curOption;
        private IList selectedDataGridRowItems = null;
        private bool isPreviousFilterEmpty = true;
        #endregion 

        public UserFrame()
        {
            InitializeComponent();

            tabControl.TabItemAdded += tabControl_TabItemAdded;
            tabControl.SelectionChanged += tabControl_SelectionChanged;
            
            //identify is this tab added or not
            Wpf.Controls.TabControl.isAdded = new BitArray(Wpf.Controls.TabControl.numOfOptions);
            //Wpf.Controls.TabControl.seqArray = new int[Wpf.Controls.TabControl.numOfOptions];

            for (int i = 0; i < Wpf.Controls.TabControl.numOfOptions; i++)
            {
                Wpf.Controls.TabControl.isAdded.Set(i, false);
                //Wpf.Controls.TabControl.seqArray[i] = -1;
            }
            
            InvTableInitial();

            //inventory chart initial
            ToggleChartVisibility();
            loadWorkInProgress();   //load work in progress           
            
        }

        private void InvTableInitial()
        {
            InvQuery = new INV_Query();
        }

        private void ShowInvTable(
            string bFilter, 
            string oFilter, 
            string proFilter,
            string locFilter,
            bool showZero)
        {
            if (showZero == true)
            {
                needTableFresh = false;
                zero.IsChecked = true;
                needTableFresh = true;
            }
            else
            {
                needTableFresh = false;
                zero.IsChecked = false;
                needTableFresh = true;
            }

            proFilter = proFilter.Equals("Product") ? string.Empty : proFilter;
            locFilter = locFilter.Equals("Location") ? string.Empty : locFilter;
                
            List<DataBaseSOH> data = InvQuery.INV_Table_Query(bFilter, oFilter, proFilter, locFilter, showZero);

            if (data == null)
            {
                //MessageBox.Show("No data table was found.");
                return;
            }


            dataGrid.ItemsSource = data;

            //load branch and owner filter
            if (InvQuery.IsFirstTime)
            {
                needTableFresh = false;  //turn of selection change
                //because set selectedindex may cause selection change event
                List<string> branch = new List<string>();
                branch.Add("All");
                foreach (string brch in InvQuery.BranchList)
                {
                    branch.Add(brch);
                }
                branchFilter.ItemsSource = branch;
                // ... Make the first item selected.
                branchFilter.SelectedIndex = 0;

                List<string> owner = new List<string>();
                owner.Add("All");
                foreach (string onr in InvQuery.OwnerList)
                {
                    owner.Add(onr);
                }
                ownerFilter.ItemsSource = owner;
                ownerFilter.SelectedIndex = 0;

                InvQuery.IsFirstTime = false;
                needTableFresh = true;  //turn on selection change
            }

        }


        #region fromTCtest
        private void tabControl_TabItemAdded(object sender, TabItemEventArgs e)
        {   

            // wrap the header in a textblock, this gives us the  character ellipsis (...) when trimmed
            TextBlock tb = new TextBlock();

            switch(SectionSelected)
            {
                case Wpf.Controls.TabControl.Section.WIP:
                    tb.Text = "Wip";
                    this.Title = "Work in Progress";
                    break;
                case Wpf.Controls.TabControl.Section.INV:
                    tb.Text = "Inv";
                    this.Title = "Inventory";
                    break;
                case Wpf.Controls.TabControl.Section.INOUT:
                    tb.Text = "InOut";
                    this.Title = "In-/OutBound";
                    break;

                case Wpf.Controls.TabControl.Section.OUTBOUND:
                    tb.Text = "Outbound";
                    this.Title = "Outbound";
                    break;
                case Wpf.Controls.TabControl.Section.INBOUND:
                    tb.Text = "Inbound";
                    this.Title = "Inbound";
                    break;
                case Wpf.Controls.TabControl.Section.RETURN:
                    tb.Text = "Return";
                    this.Title = "Return";
                    break;
                case Wpf.Controls.TabControl.Section.DOCK:
                    tb.Text = "Dock";
                    this.Title = "Dock";
                    break;

                case Wpf.Controls.TabControl.Section.REPORT:
                    tb.Text = "Reporting";
                    this.Title = "Reporting";
                    break;
                case Wpf.Controls.TabControl.Section.TASKS:
                    tb.Text = "Tasks";
                    this.Title = "Tasks";
                    break;
                case Wpf.Controls.TabControl.Section.BILL:
                    tb.Text = "Billing";
                    this.Title = "Billing";
                    break;
                case Wpf.Controls.TabControl.Section.ADMIN:
                    tb.Text = "Admin";
                    this.Title = "Admin";
                    break;
                default:
                    tb.Text = "WMS";
                    this.Title = "Warehouse Management System";
                    break;
            }

            tb.TextTrimming = TextTrimming.CharacterEllipsis;
            tb.TextWrapping = TextWrapping.NoWrap;

            e.TabItem.Header = this.Title;
        }


        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // acquire current TabItem
                Wpf.Controls.TabItem curItem = tabControl.SelectedItem as Wpf.Controls.TabItem;
                this.Title = curItem.Header.ToString();
                switch(this.Title)
                {
                    case "Work in Progress":
                        ClickHandler(Wpf.Controls.TabControl.Section.WIP);
                    break;
                    case "Inventory":
                        ClickHandler(Wpf.Controls.TabControl.Section.INV);
                        break;
                    case "In-/OutBound":
                        ClickHandler(Wpf.Controls.TabControl.Section.INOUT);
                        break;
                    case "Outbound":
                        ClickHandler(Wpf.Controls.TabControl.Section.OUTBOUND);
                        break;
                    case "Inbound":
                        ClickHandler(Wpf.Controls.TabControl.Section.INBOUND);
                        break;
                    case "Return":
                        ClickHandler(Wpf.Controls.TabControl.Section.RETURN);
                        break;
                    case "Dock":
                        ClickHandler(Wpf.Controls.TabControl.Section.DOCK);
                        break;
                    case "Reporting":
                        ClickHandler(Wpf.Controls.TabControl.Section.REPORT);
                        break;
                    case "Tasks":
                        ClickHandler(Wpf.Controls.TabControl.Section.TASKS);
                        break;
                    case "Billing":
                       ClickHandler(Wpf.Controls.TabControl.Section.BILL);
                        break;
                    case "Admin":
                        ClickHandler(Wpf.Controls.TabControl.Section.ADMIN);
                        break;
                    default:
                        break;
                }
                ToggleChartVisibility();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion fromTCtest

        #region supportFunc
        private void loadWorkInProgress()
        {
            int index = (int)Wpf.Controls.TabControl.Section.WIP;
            ClickHandler(Wpf.Controls.TabControl.Section.WIP);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.WIP, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.WIP] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.WIP);
            }
        }

        private void ClickHandler(Wpf.Controls.TabControl.Section s)
        {
            if (SectionSelected != s)
                SectionSelected = s;
        }

        //change the visibility of inventory chart

        void ToggleChartVisibility()
        {
            if (SectionSelected == Wpf.Controls.TabControl.Section.INV)
            {
                chart.Visibility = Visibility.Visible;
                InvEditFrame.Visibility = Visibility.Collapsed;
            }
            else if (chart.Visibility == Visibility.Visible)
                chart.Visibility = Visibility.Hidden;
            else if (InvEditFrame.Visibility == Visibility.Visible)
                InvEditFrame.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region EventFunc

        private void dashboard_Click(object sender, RoutedEventArgs e)
        {
            loadWorkInProgress();
            ToggleChartVisibility();
        }

        private void inventory_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.INV;
            ClickHandler(Wpf.Controls.TabControl.Section.INV);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.INV, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.INV] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.INV);
                needTableFresh = false;
                branchFilter.SelectedIndex = 0;
                ownerFilter.SelectedIndex = 0;
                needTableFresh = true;
            }
            //show table
            ShowInvTable("All", "All", string.Empty, string.Empty, false);

            //handle table content
            ToggleChartVisibility();
        }

        //private void inout_Click(object sender, RoutedEventArgs e)
        //{
        //    //ClickHandler(Wpf.Controls.TabControl.Section.INOUT);
        //    //if (!Wpf.Controls.TabControl.isAdded.Get((int)Wpf.Controls.TabControl.Section.INOUT))
        //    //{
        //    //    tabControl.AddTabItem();
        //    //    Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.INOUT, true);
        //    //}
        //    inout.Visibility = Visibility.Hidden;
        //}

        private void inout_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //showInOut();
            inout.Visibility = Visibility.Hidden;
            //SubGrid.Visibility = Visibility.Visible;
        }

        private void SubGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //showSubGrid();
            inout.Visibility = Visibility.Visible;
            //SubGrid.Visibility = Visibility.Hidden;
        }
        //private void Returns_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    showSubGrid();
        //}

        //private void Inbound_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    showSubGrid();
        //}

        //private void Outbound_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    showSubGrid();
        //}

        //private void dock_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    showSubGrid();
        //}
        //private void showInOut()
        //{
        //    inout.Visibility = Visibility.Collapsed;
        //    //SubGrid.Visibility = Visibility.Visible;
        //}

        //private void showSubGrid()
        //{
        //    inout.Visibility = Visibility.Visible;
        //    //SubGrid.Visibility = Visibility.Collapsed;
        //}

        //inout submenus
        private void Outbound_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.OUTBOUND;
            ClickHandler(Wpf.Controls.TabControl.Section.OUTBOUND);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.OUTBOUND, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.OUTBOUND] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.OUTBOUND);
            }
            ToggleChartVisibility();
        }

        private void Inbound_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.INBOUND;
            ClickHandler(Wpf.Controls.TabControl.Section.INBOUND);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.INBOUND, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.INBOUND] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.INBOUND);
            }
            ToggleChartVisibility();
        }

        private void Returns_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.RETURN;
            ClickHandler(Wpf.Controls.TabControl.Section.RETURN);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.RETURN, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.RETURN] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.RETURN);
            }
            ToggleChartVisibility();
        }

        private void dock_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.DOCK;
            ClickHandler(Wpf.Controls.TabControl.Section.DOCK);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.DOCK, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.DOCK] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.DOCK);
            }
            ToggleChartVisibility();
        }
        //inout submenus



        private void tasks_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.TASKS;
            ClickHandler(Wpf.Controls.TabControl.Section.TASKS);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.TASKS, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.TASKS] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.TASKS);
            }
            ToggleChartVisibility();
        }

        private void reports_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.REPORT;
            ClickHandler(Wpf.Controls.TabControl.Section.REPORT);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.REPORT, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.REPORT] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.REPORT);
            }
            ToggleChartVisibility();
        }

        private void billing_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.BILL;
            ClickHandler(Wpf.Controls.TabControl.Section.BILL);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.BILL, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.BILL] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.BILL);
            }
            ToggleChartVisibility();
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)Wpf.Controls.TabControl.Section.ADMIN;
            ClickHandler(Wpf.Controls.TabControl.Section.ADMIN);
            if (!Wpf.Controls.TabControl.isAdded.Get(index))
            {
                tabControl.AddTabItem(index);
                Wpf.Controls.TabControl.isAdded.Set((int)Wpf.Controls.TabControl.Section.ADMIN, true);
                //Wpf.Controls.TabControl.seqArray[(int)Wpf.Controls.TabControl.Section.ADMIN] = Wpf.Controls.TabControl.indexOfTabs++;
            }
            else
            {
                tabControl.ChangeFocus((int)Wpf.Controls.TabControl.Section.ADMIN);
            }
            ToggleChartVisibility();
        }


        private void Branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;

            if (needTableFresh)
            {
                ShowInvTable(value, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);
            }
        }

        private void Owner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;

            if (needTableFresh)
            {
                ShowInvTable(branchFilter.Text, value, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);
            }
        }

        private void branchFilter_Loaded(object sender, RoutedEventArgs e)
        {
            //initial filter
            //load branch and owner filter
            List<string> branch = new List<string>();
            branch.Add("All");
            branchFilter.ItemsSource = branch;
            // ... Make the first item selected.
            branchFilter.SelectedIndex = 0;
        }

        private void ownerFilter_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> owner = new List<string>();
            owner.Add("All");
            ownerFilter.ItemsSource = owner;
            ownerFilter.SelectedIndex = 0;
        }

        private void showZero_Unchecked(object sender, RoutedEventArgs e)
        {
            InvQuery.ShowZero = false;

            if (needTableFresh == true)
            {
                ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, false);
            }
        }

        private void showZero_Checked(object sender, RoutedEventArgs e)
        {
            InvQuery.ShowZero = true;

            if (needTableFresh == true)
            {
                ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, true);
            }
        }

        //location filter handling
        private void LocFilter_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            LocFilter.Focus();
            if (LocFilter.Text.Equals("Location"))
            {
                LocFilter.Text = string.Empty;
                //LocFilter.Style = null;
                LocFilter.Foreground = Brushes.Black;
            }
        }

        private void LocFilter_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (LocFilter.Text == string.Empty)
            {
                LocFilter.Text = "Location";
                LocFilter.Foreground = Brushes.Gray;
            }
        }

        private void LocFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (needTableFresh == true && !LocFilter.Text.Equals("Location"))
            {
                if (LocFilter.Foreground == Brushes.Gray)
                    LocFilter.Foreground = Brushes.Black;
                ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);                
            }
            if (LocFilter.IsFocused == false && LocFilter.Text.Equals(string.Empty))
            {
                LocFilter.Text = "Location";
                LocFilter.Foreground = Brushes.Gray;
            }
        }

        //Product filter handling
        private void ProFilter_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ProFilter.Focus();
            if (ProFilter.Text.Equals("Product"))
            {
                ProFilter.Text = string.Empty;
                //LocFilter.Style = null;
                ProFilter.Foreground = Brushes.Black;
            }
        }

        private void ProFilter_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            if (ProFilter.Text == string.Empty)
            {
                ProFilter.Text = "Product";
                ProFilter.Foreground = Brushes.Gray;
            }
        }

        private void ProFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (needTableFresh == true && !ProFilter.Text.Equals("Product"))
            {
                if(ProFilter.Foreground == Brushes.Gray)
                    ProFilter.Foreground = Brushes.Black;
                ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);
            }
            if (ProFilter.IsFocused == false && ProFilter.Text.Equals(string.Empty))
            {
                ProFilter.Text = "Product";
                ProFilter.Foreground = Brushes.Gray;
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            if ((ProFilter.Text.Equals(string.Empty) || ProFilter.Text.Equals("Product"))
                && (LocFilter.Text.Equals(string.Empty) || LocFilter.Text.Equals("Location")))
            {
                if (isPreviousFilterEmpty == true)
                {
                    MessageBox.Show("No location or product filter applied.");

                }
                else
                {
                    isPreviousFilterEmpty = true;
                    ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);
                }
            }
            else
            {
                isPreviousFilterEmpty = false;
                ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);
            }
        }
        #endregion     

        #region right_click_and_modify_entry

        private void AdjustQuantity_Click(object sender, RoutedEventArgs e)
        {
            curOption = AttributesEditOption.AdjQTY;
            InvEditFrameSetup(curOption);           
        }

        private void AdjustAttributes_Click(object sender, RoutedEventArgs e)
        {
            curOption = AttributesEditOption.AdjAttr;
            InvEditFrameSetup(curOption);  
        }

        private void AdjustStockStatus_Click(object sender, RoutedEventArgs e)
        {
            curOption = AttributesEditOption.AdjStkStats;
            InvEditFrameSetup(curOption);
        }

        private void InvEditFrameSetup(AttributesEditOption option)
        {
            chart.Visibility = Visibility.Hidden;
            InvEditFrame.Visibility = Visibility.Visible;

            //get current row
            DataGridRow curRow = GetListViewItem(dataGrid.SelectedIndex, dataGrid);

            DataBaseSOH selectedSOH = curRow.Item as DataBaseSOH;

            switch (option)  //different edit field due to right clicked selection
            {
                case AttributesEditOption.AdjQTY:
                    QTYField.Text = selectedSOH.QTY.ToString();

                    Attr1FieldReadOnly.Text = selectedSOH.Attribute1;
                    Attr2FieldReadOnly.Text = selectedSOH.Attribute2;
                    Attr3FieldReadOnly.Text = selectedSOH.Attribute3;
                    Attr4FieldReadOnly.Text = selectedSOH.Attribute4;
                    Attr5FieldReadOnly.Text = selectedSOH.Attribute5;
                    StockFieldReadOnly.Text = selectedSOH.StockStatus;

                    QTYField.Visibility = Visibility.Visible;
                    QTYFieldReadOnly.Visibility = Visibility.Hidden;
                    StockField.Visibility = Visibility.Hidden;
                    StockFieldReadOnly.Visibility = Visibility.Visible;
                    Attr1Field.Visibility = Visibility.Hidden;
                    Attr1FieldReadOnly.Visibility = Visibility.Visible;
                    Attr2Field.Visibility = Visibility.Hidden;
                    Attr2FieldReadOnly.Visibility = Visibility.Visible;
                    Attr3Field.Visibility = Visibility.Hidden;
                    Attr3FieldReadOnly.Visibility = Visibility.Visible;
                    Attr4Field.Visibility = Visibility.Hidden;
                    Attr4FieldReadOnly.Visibility = Visibility.Visible;
                    Attr5Field.Visibility = Visibility.Hidden;
                    Attr5FieldReadOnly.Visibility = Visibility.Visible;

                    break;
                case AttributesEditOption.AdjAttr:
                    QTYFieldReadOnly.Text = selectedSOH.QTY.ToString();
                    StockFieldReadOnly.Text = selectedSOH.StockStatus;

                    Attr1Field.Text = selectedSOH.Attribute1;
                    Attr2Field.Text = selectedSOH.Attribute2;
                    Attr3Field.Text = selectedSOH.Attribute3;
                    Attr4Field.Text = selectedSOH.Attribute4;
                    Attr5Field.Text = selectedSOH.Attribute5;

                    QTYField.Visibility = Visibility.Hidden;
                    QTYFieldReadOnly.Visibility = Visibility.Visible;
                    StockField.Visibility = Visibility.Hidden;
                    StockFieldReadOnly.Visibility = Visibility.Visible;
                    Attr1Field.Visibility = Visibility.Visible;
                    Attr1FieldReadOnly.Visibility = Visibility.Hidden;
                    Attr2Field.Visibility = Visibility.Visible;
                    Attr2FieldReadOnly.Visibility = Visibility.Hidden;
                    Attr3Field.Visibility = Visibility.Visible;
                    Attr3FieldReadOnly.Visibility = Visibility.Hidden;
                    Attr4Field.Visibility = Visibility.Visible;
                    Attr4FieldReadOnly.Visibility = Visibility.Hidden;
                    Attr5Field.Visibility = Visibility.Visible;
                    Attr5FieldReadOnly.Visibility = Visibility.Hidden;
                    break;
                case AttributesEditOption.AdjStkStats:
                    QTYFieldReadOnly.Text = selectedSOH.QTY.ToString();
                    StockField.Text = selectedSOH.StockStatus;

                    Attr1FieldReadOnly.Text = selectedSOH.Attribute1;
                    Attr2FieldReadOnly.Text = selectedSOH.Attribute2;
                    Attr3FieldReadOnly.Text = selectedSOH.Attribute3;
                    Attr4FieldReadOnly.Text = selectedSOH.Attribute4;
                    Attr5FieldReadOnly.Text = selectedSOH.Attribute5;

                    QTYField.Visibility = Visibility.Hidden;
                    QTYFieldReadOnly.Visibility = Visibility.Visible;
                    StockField.Visibility = Visibility.Visible;
                    StockFieldReadOnly.Visibility = Visibility.Hidden;
                    Attr1Field.Visibility = Visibility.Hidden;
                    Attr1FieldReadOnly.Visibility = Visibility.Visible;
                    Attr2Field.Visibility = Visibility.Hidden;
                    Attr2FieldReadOnly.Visibility = Visibility.Visible;
                    Attr3Field.Visibility = Visibility.Hidden;
                    Attr3FieldReadOnly.Visibility = Visibility.Visible;
                    Attr4Field.Visibility = Visibility.Hidden;
                    Attr4FieldReadOnly.Visibility = Visibility.Visible;
                    Attr5Field.Visibility = Visibility.Hidden;
                    Attr5FieldReadOnly.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
            //set textbox field
            BranchFieldReadOnly.Text = selectedSOH.Branch;
            OwnerFieldReadOnly.Text = selectedSOH.Owner;
            PcodeFieldReadOnly.Text = selectedSOH.ProductCode;
            ColourFieldReadOnly.Text = selectedSOH.Colour;
            SizeFieldReadOnly.Text = selectedSOH.Size;
            LocationFieldReadOnly.Text = selectedSOH.Location;
            UOMFieldReadOnly.Text = selectedSOH.UOM;
            ArrivalFieldReadOnly.Text = selectedSOH.Arrival;
            ExpiryFieldReadOnly.Text = selectedSOH.ExpiryDate;
            SNFieldReadOnly.Text = selectedSOH.SerialNumber;
            BatchFieldReadOnly.Text = selectedSOH.BatchNumber;

            BranchField.Visibility = Visibility.Hidden;
            OwnerField.Visibility = Visibility.Hidden;
            PcodeField.Visibility = Visibility.Hidden;
            ColourField.Visibility = Visibility.Hidden;
            SizeField.Visibility = Visibility.Hidden;
            LocationField.Visibility = Visibility.Hidden;
            UOMField.Visibility = Visibility.Hidden;
            ArrivalField.Visibility = Visibility.Hidden;
            ExpiryField.Visibility = Visibility.Hidden;
            SNField.Visibility = Visibility.Hidden;
            BatchField.Visibility = Visibility.Hidden;

            BranchFieldReadOnly.Visibility = Visibility.Visible;
            OwnerFieldReadOnly.Visibility = Visibility.Visible;
            PcodeFieldReadOnly.Visibility = Visibility.Visible;
            ColourFieldReadOnly.Visibility = Visibility.Visible;
            SizeFieldReadOnly.Visibility = Visibility.Visible;
            LocationFieldReadOnly.Visibility = Visibility.Visible;
            UOMFieldReadOnly.Visibility = Visibility.Visible;
            ArrivalFieldReadOnly.Visibility = Visibility.Visible;
            ExpiryFieldReadOnly.Visibility = Visibility.Visible;
            SNFieldReadOnly.Visibility = Visibility.Visible;
            BatchFieldReadOnly.Visibility = Visibility.Visible;
        }

        private void CreateNewStock_Click(object sender, RoutedEventArgs e)
        {
            NewStockCreate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewStockCreate();
        }

        private void NewStockCreate()
        {
            curOption = AttributesEditOption.CreateNew;
            chart.Visibility = Visibility.Hidden;
            InvEditFrame.Visibility = Visibility.Visible;

            //set textbox field
            BranchFieldReadOnly.Text = string.Empty;
            OwnerFieldReadOnly.Text = string.Empty;
            PcodeFieldReadOnly.Text = string.Empty;
            ColourFieldReadOnly.Text = string.Empty;
            SizeFieldReadOnly.Text = string.Empty;
            LocationFieldReadOnly.Text = string.Empty;
            UOMFieldReadOnly.Text = string.Empty;
            ArrivalFieldReadOnly.Text = string.Empty;
            ExpiryFieldReadOnly.Text = string.Empty;
            SNFieldReadOnly.Text = string.Empty;
            BatchFieldReadOnly.Text = string.Empty;

            QTYField.Text = string.Empty;
            StockField.Text = string.Empty;

            Attr1Field.Text = string.Empty;
            Attr2Field.Text = string.Empty;
            Attr3Field.Text = string.Empty;
            Attr4Field.Text = string.Empty;
            Attr5Field.Text = string.Empty;

            QTYField.Visibility = Visibility.Visible;
            StockField.Visibility = Visibility.Visible;
            Attr1Field.Visibility = Visibility.Visible;
            Attr2Field.Visibility = Visibility.Visible;
            Attr3Field.Visibility = Visibility.Visible;
            Attr4Field.Visibility = Visibility.Visible;
            Attr5Field.Visibility = Visibility.Visible;
            BranchField.Visibility = Visibility.Visible;
            OwnerField.Visibility = Visibility.Visible;
            PcodeField.Visibility = Visibility.Visible;
            ColourField.Visibility = Visibility.Visible;
            SizeField.Visibility = Visibility.Visible;
            LocationField.Visibility = Visibility.Visible;
            UOMField.Visibility = Visibility.Visible;
            ArrivalField.Visibility = Visibility.Visible;
            ExpiryField.Visibility = Visibility.Visible;
            SNField.Visibility = Visibility.Visible;
            BatchField.Visibility = Visibility.Visible;

            QTYFieldReadOnly.Visibility = Visibility.Hidden;
            StockFieldReadOnly.Visibility = Visibility.Hidden;
            Attr1FieldReadOnly.Visibility = Visibility.Hidden;
            Attr2FieldReadOnly.Visibility = Visibility.Hidden;
            Attr3FieldReadOnly.Visibility = Visibility.Hidden;
            Attr4FieldReadOnly.Visibility = Visibility.Hidden;
            Attr5FieldReadOnly.Visibility = Visibility.Hidden;
            BranchFieldReadOnly.Visibility = Visibility.Hidden;
            OwnerFieldReadOnly.Visibility = Visibility.Hidden;
            PcodeFieldReadOnly.Visibility = Visibility.Hidden;
            ColourFieldReadOnly.Visibility = Visibility.Hidden;
            SizeFieldReadOnly.Visibility = Visibility.Hidden;
            LocationFieldReadOnly.Visibility = Visibility.Hidden;
            UOMFieldReadOnly.Visibility = Visibility.Hidden;
            ArrivalFieldReadOnly.Visibility = Visibility.Hidden;
            ExpiryFieldReadOnly.Visibility = Visibility.Hidden;
            SNFieldReadOnly.Visibility = Visibility.Hidden;
            BatchFieldReadOnly.Visibility = Visibility.Hidden;
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {

            if (curOption != AttributesEditOption.CreateNew)
            {
                float curQTY = 0, prevQTY = 0;
                string JobNum = string.Empty;
                string JobType = string.Empty;

                if (curOption == AttributesEditOption.AdjQTY)
                {
                    curQTY = float.Parse(QTYField.Text);
                    if (curQTY < 0)
                    {
                        MessageBox.Show("Item quantity should not be negative!");
                        return;
                    }//QTY must be positive
                }

                //get current row
                DataGridRow curRow = GetListViewItem(dataGrid.SelectedIndex, dataGrid);
                DataBaseSOH selectedSOH = curRow.Item as DataBaseSOH;

                // check if any difference had been made
                if (curOption == AttributesEditOption.AdjQTY)
                {
                    prevQTY = selectedSOH.QTY;
                    if (curQTY == prevQTY)
                    {
                        MessageBox.Show("No change discovered!");
                        return;
                    }
                    //selectedSOH.Branch = BranchField.Text;
                    selectedSOH.QTY = curQTY;
                    JobNum = "ADJ";
                    JobType = "ADJ";
                }
                else if (curOption == AttributesEditOption.AdjAttr)
                {
                    if (Attr1Field.Text.Equals(selectedSOH.Attribute1)
                        && Attr2Field.Text.Equals(selectedSOH.Attribute2)
                        && Attr3Field.Text.Equals(selectedSOH.Attribute3)
                        && Attr4Field.Text.Equals(selectedSOH.Attribute4)
                        && Attr5Field.Text.Equals(selectedSOH.Attribute5))
                    {
                        MessageBox.Show("No change discovered!");
                        return;
                    }
                    selectedSOH.Attribute1 = Attr1Field.Text;
                    selectedSOH.Attribute2 = Attr2Field.Text;
                    selectedSOH.Attribute3 = Attr3Field.Text;
                    selectedSOH.Attribute4 = Attr4Field.Text;
                    selectedSOH.Attribute5 = Attr5Field.Text;
                    JobNum = "ATTR";
                    JobType = "ADJ";
                }
                else if (curOption == AttributesEditOption.AdjStkStats)
                {
                    if (StockField.Text.Equals(selectedSOH.StockStatus))
                    {
                        MessageBox.Show("No change discovered!");
                        return;
                    }
                    selectedSOH.StockStatus = StockField.Text;
                    JobType = "STA";
                    JobNum = "STATUS";
                }

                if (!(Reason1.IsChecked == true) && !(Reason2.IsChecked == true) && !(Reason3.IsChecked == true)
                    && !(Reason4.IsChecked == true) && !(Reason5.IsChecked == true) && !(Reason6.IsChecked == true)
                    && !(Reason7.IsChecked == true))
                {
                    MessageBox.Show("You need to choose or write a specific reason!");
                    return;
                }
                else if ((Reason7.IsChecked == true) && (ReasonField.Text == string.Empty))
                {
                    MessageBox.Show("You need to choose or write a specific reason!");
                    return;
                }

                DataBaseTranHistory newTrans = new DataBaseTranHistory();
                {
                    newTrans.RecordIdentifier = "TRN";
                    newTrans.Type = JobType;
                    newTrans.Date = DateTime.Today;
                    newTrans.Time = DateTime.Now.TimeOfDay;
                    newTrans.User = CONNECTION.DbHandle.Username;
                    newTrans.Owner = selectedSOH.Owner;
                    newTrans.ProductCode = selectedSOH.ProductCode;
                    newTrans.Colour = selectedSOH.Colour;
                    newTrans.Size = selectedSOH.Size;
                    newTrans.Location = selectedSOH.Location;
                    newTrans.UOM = selectedSOH.UOM;
                    newTrans.QTY = selectedSOH.QTY - prevQTY;
                    newTrans.JobNumber = JobNum;
                    newTrans.ArrivalDate = selectedSOH.ArrivalDate;
                    newTrans.BatchNumber = selectedSOH.BatchNumber;
                    newTrans.ExpiryDate = (selectedSOH.ExpiryDate == null) ? DateTime.MaxValue : Convert.ToDateTime(selectedSOH.ExpiryDate);
                    newTrans.SerialNumber = selectedSOH.SerialNumber;
                    newTrans.Attribute1 = selectedSOH.Attribute1;
                    newTrans.Attribute2 = selectedSOH.Attribute2;
                    newTrans.Attribute3 = selectedSOH.Attribute3;
                    newTrans.Attribute4 = selectedSOH.Attribute4;
                    newTrans.Attribute5 = selectedSOH.Attribute5;
                    newTrans.StockStatus = selectedSOH.StockStatus;
                    newTrans.ReasonCode = UserFrame.ReasonCode;
                    newTrans.Notes = ReasonField.Text;
                }
                try
                {
                    DataBaseSOH.UpdateDataBaseSOH(selectedSOH, newTrans);    //can be made easier if only QTY is allowed to change              
                    InvEditFrame.Visibility = Visibility.Collapsed;
                    ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);
                    chart.Visibility = Visibility.Visible;
                    resetSelection();
                }
                catch 
                {
                    MessageBox.Show("Update Data Error!");
                }
            }
            else
            {
                if (BranchField.Text.Equals(string.Empty)
                    || OwnerField.Text.Equals(string.Empty)
                    || PcodeField.Text.Equals(string.Empty)
                    || LocationField.Text.Equals(string.Empty)
                    || UOMField.Text.Equals(string.Empty)
                    || QTYField.Text.Equals(string.Empty)
                    || ArrivalField.Text.Equals(string.Empty)
                    || ColourField.Text.Equals(string.Empty)
                    || SizeField.Text.Equals(string.Empty)
                    || StockField.Text.Equals(string.Empty))
                {
                    MessageBox.Show("You should complete all red compulsory field!");
                    return;
                }
                if (!(Reason1.IsChecked == true) && !(Reason2.IsChecked == true) && !(Reason3.IsChecked == true)
                    && !(Reason4.IsChecked == true) && !(Reason5.IsChecked == true) && !(Reason6.IsChecked == true)
                    && !(Reason7.IsChecked == true))
                {
                    MessageBox.Show("You need to choose or write a specific reason!");
                    return;
                }
                else if ((Reason7.IsChecked == true) && (ReasonField.Text == string.Empty))
                {
                    MessageBox.Show("You need to choose or write a specific reason!");
                    return;
                }
                if (0 > float.Parse(QTYField.Text))
                {
                    MessageBox.Show("Item quantity should not be negative!");
                    return;
                }
                DataBaseSOH newSOH = new DataBaseSOH()
                {
                    RecordIdentifier = "SOH",
                    Branch = BranchField.Text,
                    Owner = OwnerField.Text,
                    ProductCode = PcodeField.Text,
                    Colour = ColourField.Text,
                    Size = SizeField.Text,
                    Location = LocationField.Text,
                    UOM = UOMField.Text,
                    QTY = float.Parse(QTYField.Text),
                    ArrivalDate = Convert.ToDateTime(ArrivalField.Text),
                    BatchNumber = BatchField.Text.Trim() == string.Empty ? null : BatchField.Text.Trim(),
                    ExpiryDate = ExpiryField.Text.Trim() == string.Empty ? null : ExpiryField.Text.Trim(),
                    SerialNumber = SNField.Text.Trim() == string.Empty ? null : SNField.Text.Trim(),
                    Attribute1 = Attr1Field.Text.Trim() == string.Empty ? null : Attr1Field.Text.Trim(),
                    Attribute2 = Attr2Field.Text.Trim() == string.Empty ? null : Attr2Field.Text.Trim(),
                    Attribute3 = Attr3Field.Text.Trim() == string.Empty ? null : Attr3Field.Text.Trim(),
                    Attribute4 = Attr4Field.Text.Trim() == string.Empty ? null : Attr4Field.Text.Trim(),
                    Attribute5 = Attr5Field.Text.Trim() == string.Empty ? null : Attr5Field.Text.Trim(),
                    StockStatus = StockField.Text
                };

                DataBaseTranHistory newTrans = new DataBaseTranHistory();
                {
                    newTrans.RecordIdentifier = "TRN";
                    newTrans.Type = "CRT";
                    newTrans.Date = DateTime.Today;
                    newTrans.Time = DateTime.Now.TimeOfDay;
                    newTrans.User = CONNECTION.DbHandle.Username;
                    newTrans.Owner = newSOH.Owner;
                    newTrans.ProductCode = newSOH.ProductCode;
                    newTrans.Colour = newSOH.Colour;
                    newTrans.Size = newSOH.Size;
                    newTrans.Location = newSOH.Location;
                    newTrans.UOM = newSOH.UOM;
                    newTrans.QTY = newSOH.QTY;
                    newTrans.JobNumber = "CREATE";
                    newTrans.ArrivalDate = newSOH.ArrivalDate;
                    newTrans.BatchNumber = newSOH.BatchNumber;
                    newTrans.ExpiryDate = (newSOH.ExpiryDate == null) ? DateTime.MaxValue : Convert.ToDateTime(newSOH.ExpiryDate);
                    newTrans.SerialNumber = newSOH.SerialNumber;
                    newTrans.Attribute1 = newSOH.Attribute1;
                    newTrans.Attribute2 = newSOH.Attribute2;
                    newTrans.Attribute3 = newSOH.Attribute3;
                    newTrans.Attribute4 = newSOH.Attribute4;
                    newTrans.Attribute5 = newSOH.Attribute5;
                    newTrans.StockStatus = newSOH.StockStatus;
                    newTrans.ReasonCode = UserFrame.ReasonCode;
                    newTrans.Notes = ReasonField.Text;
                }
                try
                {
                    DataBaseSOH.AddDataBaseSOH(newSOH, newTrans);    //can be made easier if only QTY is allowed to change               
                    InvEditFrame.Visibility = Visibility.Collapsed;
                    ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);
                    chart.Visibility = Visibility.Visible;
                    resetSelection();
                }
                catch 
                {
                    MessageBox.Show("Add Data Error!");
                }
            }
            
        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            InvEditFrame.Visibility = Visibility.Collapsed;
            chart.Visibility = Visibility.Visible;
            resetSelection();
        }

        private void resetSelection()
        {
            ReasonCode = (int)(ReasonCodes.NULL);
            ReasonField.Text = string.Empty;
            ReasonField.IsReadOnly = true;

            Reason1.IsChecked = false;
            Reason2.IsChecked = false;
            Reason3.IsChecked = false;
            Reason4.IsChecked = false;
            Reason5.IsChecked = false;
            Reason6.IsChecked = false;
            Reason7.IsChecked = false;
        }

        //stock status conversion
        private void Convert2DMG_Click(object sender, RoutedEventArgs e)
        {
            curOption = AttributesEditOption.Cvt2DMG;
            MultipleConversion("DMG");
        }
        private void Convert2AVL_Click(object sender, RoutedEventArgs e)
        {
            curOption = AttributesEditOption.Cvt2AVL;
            MultipleConversion("AVL");
        }

        //CONVERT all DMG to AVL or reverse
        private void MultipleConversion(string stockStatus)
        {
            bool isUpdated = false;
            foreach (DataBaseSOH curSOH in dataGrid.SelectedItems)
            {
                if (curSOH.StockStatus.Equals(stockStatus)) continue;
                curSOH.StockStatus = stockStatus;

                //update transaction
                DataBaseTranHistory newTrans = new DataBaseTranHistory();
                {
                    newTrans.RecordIdentifier = "TRN";
                    newTrans.Type = "STK";
                    newTrans.Date = DateTime.Today;
                    newTrans.Time = DateTime.Now.TimeOfDay;
                    newTrans.User = CONNECTION.DbHandle.Username;
                    newTrans.Owner = curSOH.Owner;
                    newTrans.ProductCode = curSOH.ProductCode;
                    newTrans.Colour = curSOH.Colour;
                    newTrans.Size = curSOH.Size;
                    newTrans.Location = curSOH.Location;
                    newTrans.UOM = curSOH.UOM;
                    newTrans.QTY = curSOH.QTY;
                    newTrans.JobNumber = "ChgStkSta";
                    newTrans.ArrivalDate = curSOH.ArrivalDate;
                    newTrans.BatchNumber = curSOH.BatchNumber;
                    newTrans.ExpiryDate = (curSOH.ExpiryDate==null) ? DateTime.MaxValue : Convert.ToDateTime(curSOH.ExpiryDate);
                    newTrans.SerialNumber = curSOH.SerialNumber;
                    newTrans.Attribute1 = curSOH.Attribute1;
                    newTrans.Attribute2 = curSOH.Attribute2;
                    newTrans.Attribute3 = curSOH.Attribute3;
                    newTrans.Attribute4 = curSOH.Attribute4;
                    newTrans.Attribute5 = curSOH.Attribute5;
                    newTrans.StockStatus = curSOH.StockStatus;
                    newTrans.ReasonCode = (int)(ReasonCodes.StkChg);
                    newTrans.Notes = "Change Stock Status to" + stockStatus;
                }
                try
                {
                    DataBaseSOH.UpdateDataBaseSOH(curSOH, newTrans);
                    isUpdated = true;
                }
                catch
                {
                    MessageBox.Show("Update Data Error!");
                }
            }
            if (isUpdated == true)
                ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);//refresh
        }

        //change stock location
        private void ChangeLoc_Click(object sender, RoutedEventArgs e)
        {
            curOption = AttributesEditOption.ChgLoc;
            InputBox.Visibility = Visibility.Visible;

        }

        //same as yesbuttonclicked
        private void InputTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChangeLocation();
            }
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeLocation();                 
        }
        private void ChangeLocation()
        {
            InputBox.Visibility = Visibility.Collapsed;

            String location = InputTextBox.Text;
            InputTextBox.Text = String.Empty;

            bool isUpdated = false;
            foreach (DataBaseSOH curSOH in dataGrid.SelectedItems)
            {
                if (curSOH.Location.Equals(location)) continue;

                //curSOH.Location = location;   no need, we want to change the location can be read from newTrans

                //update transaction
                DataBaseTranHistory newTrans = new DataBaseTranHistory();
                {
                    newTrans.RecordIdentifier = "TRN";
                    newTrans.Type = "LOC";
                    newTrans.Date = DateTime.Today;
                    newTrans.Time = DateTime.Now.TimeOfDay;
                    newTrans.User = CONNECTION.DbHandle.Username;
                    newTrans.Owner = curSOH.Owner;
                    newTrans.ProductCode = curSOH.ProductCode;
                    newTrans.Colour = curSOH.Colour;
                    newTrans.Size = curSOH.Size;
                    newTrans.Location = location;
                    newTrans.UOM = curSOH.UOM;
                    newTrans.QTY = curSOH.QTY;
                    newTrans.JobNumber = "ChgLoc";
                    newTrans.ArrivalDate = curSOH.ArrivalDate;
                    newTrans.BatchNumber = curSOH.BatchNumber;
                    newTrans.ExpiryDate = (curSOH.ExpiryDate == null) ? DateTime.MaxValue : Convert.ToDateTime(curSOH.ExpiryDate);
                    newTrans.SerialNumber = curSOH.SerialNumber;
                    newTrans.Attribute1 = curSOH.Attribute1;
                    newTrans.Attribute2 = curSOH.Attribute2;
                    newTrans.Attribute3 = curSOH.Attribute3;
                    newTrans.Attribute4 = curSOH.Attribute4;
                    newTrans.Attribute5 = curSOH.Attribute5;
                    newTrans.StockStatus = curSOH.StockStatus;
                    newTrans.ReasonCode = (int)(ReasonCodes.LocChg);
                    newTrans.Notes = "Change Location to" + location;
                }
                try
                {
                    DataBaseSOH.UpdateDataBaseSOH(curSOH, newTrans);
                    isUpdated = true;
                }
                catch
                {
                    MessageBox.Show("Update Data Error!");
                }
            }
            if (isUpdated == true)
                ShowInvTable(branchFilter.Text, ownerFilter.Text, ProFilter.Text, LocFilter.Text, InvQuery.ShowZero);//refresh
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
            InputTextBox.Text = String.Empty;
        }

        //reason field code
        #region ReasonCode
        public static int ReasonCode;

        private void Reason1_Checked(object sender, RoutedEventArgs e)
        {
            ReasonCode = (int)(ReasonCodes.Load);
            ReasonField.Text = "Initial Stock Load";
            ReasonField.IsReadOnly = true;
            ReasonField.Visibility = Visibility.Hidden;
        }
        private void Reason2_Checked(object sender, RoutedEventArgs e)
        {

            ReasonCode = (int)(ReasonCodes.QTYAdj);
            ReasonField.Text = "TS stock adjustment";
            ReasonField.IsReadOnly = true;
            ReasonField.Visibility = Visibility.Hidden;
        }
        private void Reason3_Checked(object sender, RoutedEventArgs e)
        {
            ReasonCode = (int)(ReasonCodes.StkChg);
            ReasonField.Text = "Stock status change";
            ReasonField.IsReadOnly = true;
            ReasonField.Visibility = Visibility.Hidden;
        }
        private void Reason4_Checked(object sender, RoutedEventArgs e)
        {        
            ReasonCode = (int)(ReasonCodes.AttrAdj);
            ReasonField.Text = "Stock attributes change";
            ReasonField.IsReadOnly = true;
            ReasonField.Visibility = Visibility.Hidden;
        }
        private void Reason5_Checked(object sender, RoutedEventArgs e)
        {
            ReasonCode = (int)(ReasonCodes.LocChg);
            ReasonField.IsReadOnly = true;
            ReasonField.Text = "Change Location";
            ReasonField.Visibility = Visibility.Hidden;
        }
        private void Reason6_Checked(object sender, RoutedEventArgs e)
        {
            ReasonCode = (int)(ReasonCodes.NewItem);
            ReasonField.IsReadOnly = true;
            ReasonField.Text = "Stock Creation";
            ReasonField.Visibility = Visibility.Hidden;           
        }
        private void Reason7_Checked(object sender, RoutedEventArgs e)
        {
            ReasonField.Text = string.Empty;
            ReasonField.IsReadOnly = false;
            ReasonField.Visibility = Visibility.Hidden;
            ReasonCode = (int)(ReasonCodes.Other);           
        }

        #endregion
        #endregion

        //get current selected item by right click
        #region right_click_selected
        private DataGridRow GetListViewItem(int index, DataGrid datagrid)
        {
            if (datagrid.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
                return null;
            return datagrid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
        }

        private void dataGrid_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int _OldIndex = this.GetCurrentIndex(e.GetPosition, dataGrid);
            if (_OldIndex < 0)
                return;

            
            bool multiSelected = false;

            //right clicked on one of the highlighted item would be two selections
            //otherwise, show menus of modifying only one item
            if (dataGrid.SelectedItems != null)
            {
                foreach (object item in dataGrid.SelectedItems)
                {
                    if (item.Equals(GetListViewItem(_OldIndex, dataGrid).Item))
                    {
                        multiSelected = true;
                        break;
                    }
                }
            }

            if (multiSelected == false)
            {
                dataGrid.SelectedItems.Clear();
                dataGrid.SelectedItems.Add(GetListViewItem(_OldIndex, dataGrid));
            }

            selectedDataGridRowItems = dataGrid.SelectedItems;


            if (selectedDataGridRowItems.Count > 1)
            {
                AdjustQuantity.Visibility = Visibility.Collapsed;
                AdjustStockStatus.Visibility = Visibility.Collapsed;
                AdjustAttributes.Visibility = Visibility.Collapsed;
                CreateNewStock.Visibility = Visibility.Collapsed;
                Convert2DMG.Visibility = Visibility.Visible;
                Convert2AVL.Visibility = Visibility.Visible;
            }
            else
            {
                AdjustQuantity.Visibility = Visibility.Visible;
                AdjustStockStatus.Visibility = Visibility.Visible;
                AdjustAttributes.Visibility = Visibility.Visible;
                CreateNewStock.Visibility = Visibility.Visible;
                Convert2DMG.Visibility = Visibility.Collapsed;
                Convert2AVL.Visibility = Visibility.Collapsed;
                dataGrid.SelectedIndex = _OldIndex;
            }
            
        }

        private int GetCurrentIndex(GetPositionDelegate getPosition, DataGrid datagrid)
        {
            int _Index = -1;
            for (int _RowCount = 0; _RowCount < datagrid.Items.Count; ++_RowCount)
            {
                DataGridRow _Item = GetListViewItem(_RowCount, datagrid);
                if (this.IsMouseOverTarget(_Item, getPosition))
                {
                    _Index = _RowCount;
                    break;
                }
            }
            return _Index;
        }

        bool IsMouseOverTarget(Visual target, GetPositionDelegate getPosition)
        {
            Rect bounds = VisualTreeHelper.GetDescendantBounds(target);
            Point mousePos = getPosition((IInputElement)target);
            return bounds.Contains(mousePos);
        }

        delegate Point GetPositionDelegate(IInputElement element);
        #endregion 
  
    }
    public enum AttributesEditOption
    {
        AdjQTY,
        AdjAttr,
        AdjStkStats,
        ChgLoc,
        CreateNew,
        Cvt2DMG,
        Cvt2AVL
    }
    public enum ReasonCodes
    {
        NULL = 0,
        Load = 1,
        QTYAdj = 2,
        StkChg = 3,
        AttrAdj = 4,
        LocChg = 5,
        NewItem = 6,
        Other = 7
    }
}
