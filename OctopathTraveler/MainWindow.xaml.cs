using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace OctopathTraveler
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;
			if (!System.IO.File.Exists(files[0])) return;

			SaveData.Instance().Open(files[0]);
			Init();
			MessageBox.Show(Properties.Resources.MessageLoadSuccess);
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			Load(false);
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void MenuItemFileSaveAs_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().SaveAs(dlg.FileName) == true) MessageBox.Show(Properties.Resources.MessageSaveSuccess);
			else MessageBox.Show(Properties.Resources.MeaageSaveFail);
		}

		private void MenuItemExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			new AboutWindow().ShowDialog();
		}

		private void ToolBarFileOpen_Click(object sender, RoutedEventArgs e)
		{
			Load(false);
		}

		private void ToolBarFileSave_Click(object sender, RoutedEventArgs e)
		{
			Save();
		}

		private void Init()
		{
			DataContext = new DataContext();
		}

		private void Load(bool force)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Open(dlg.FileName);
			Init();
			MessageBox.Show(Properties.Resources.MessageLoadSuccess);
		}

		private void Save()
		{
			if (SaveData.Instance().Save() == true) MessageBox.Show(Properties.Resources.MessageSaveSuccess);
			else MessageBox.Show(Properties.Resources.MeaageSaveFail);
		}

		private void ButtonSword_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if(chara != null)
			{
				chara.Sword = ChoiceEquipment(chara.Sword);
			}
		}

		private void ButtonLance_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Lance = ChoiceEquipment(chara.Lance);
			}
		}

		private void ButtonDagger_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Dagger = ChoiceEquipment(chara.Dagger);
			}
		}

		private void ButtonAxe_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Axe = ChoiceEquipment(chara.Axe);
			}
		}

		private void ButtonBow_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Bow = ChoiceEquipment(chara.Bow);
			}
		}

		private void ButtonRod_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Rod = ChoiceEquipment(chara.Rod);
			}
		}

		private void ButtonShield_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Shield = ChoiceEquipment(chara.Shield);
			}
		}

		private void ButtonHead_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Head = ChoiceEquipment(chara.Head);
			}
		}

		private void ButtonBody_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Body = ChoiceEquipment(chara.Body);
			}
		}

		private void ButtonAccessory1_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Accessory1 = ChoiceEquipment(chara.Accessory1);
			}
		}

		private void ButtonAccessory2_Click(object sender, RoutedEventArgs e)
		{
			Charactor chara = CharactorList.SelectedItem as Charactor;
			if (chara != null)
			{
				chara.Accessory2 = ChoiceEquipment(chara.Accessory2);
			}
		}

		private void ButtonItem_Click(object sender, RoutedEventArgs e)
		{
			Item item = (sender as Button)?.DataContext as Item;
			if(item != null)
			{
				ItemChoiceWindow window = new ItemChoiceWindow();
				window.Type = ItemChoiceWindow.eType.item;
				window.ID = item.ID;
				window.ShowDialog();
				item.ID = window.ID;
			}
		}

		private uint ChoiceEquipment(uint id)
		{
			ItemChoiceWindow window = new ItemChoiceWindow();
			window.ID = id;
			window.ShowDialog();
			return window.ID;
		}
	}
}
