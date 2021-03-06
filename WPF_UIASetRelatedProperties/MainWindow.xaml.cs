﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_UIASetRelatedProperties
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // The "MyVeryOwnControl" stuff won't work with pre-4.8 .NET Frameworks.

            //this.MyControlOne.PositionInSet = 1;
            //this.MyControlOne.SizeOfSet = 3;
            //this.MyControlTwo.PositionInSet = 2;
            //this.MyControlTwo.SizeOfSet = 3;
            //this.MyControlThree.PositionInSet = 3;
            //this.MyControlThree.SizeOfSet = 3;
        }
    }

    //public class MyVeryOwnControl : UserControl
    //{
    //    public int PositionInSet { get; set; }
    //    public int SizeOfSet { get; set; }

    //    protected override AutomationPeer OnCreateAutomationPeer()
    //    {
    //        return new MyVeryOwnControlAutomationPeer(this);
    //    }
    //}

    //public class MyVeryOwnControlAutomationPeer : UserControlAutomationPeer
    //{
    //    private MyVeryOwnControl owner;

    //    public MyVeryOwnControlAutomationPeer(MyVeryOwnControl owner) :
    //        base(owner)
    //    {
    //        this.owner = owner;
    //    }

    //    protected override int GetPositionInSetCore()
    //    {
    //        return this.owner.PositionInSet;
    //    }

    //    protected override int GetSizeOfSetCore()
    //    {
    //        return this.owner.SizeOfSet;
    //    }

    //    // Other stuff...
    //    protected override string GetLocalizedControlTypeCore()
    //    {
    //        return "Bird"; // Localize this!
    //    }
    //}


    // The MyTablikeStackPanel is a StackPanel that claims to be a Tab.
    public class MyTablikeStackPanel : StackPanel
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new MyTablikeStackPanelAutomationPeer(this);
        }
    }

    public class MyTablikeStackPanelAutomationPeer : FrameworkElementAutomationPeer
    {
        public MyTablikeStackPanelAutomationPeer(MyTablikeStackPanel owner) :
            base(owner)
        {
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Tab;
        }
    }

    // The MyTabitemlikeRadioButton is a RadioButton that claims to be a TabItem.
    public class MyTabitemlikeRadioButton : RadioButton
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new MyTabitemlikeRadioButtonAutomationPeer(this);
        }
    }

    public class MyTabitemlikeRadioButtonAutomationPeer : RadioButtonAutomationPeer
    {
        public MyTabitemlikeRadioButtonAutomationPeer(MyTabitemlikeRadioButton owner) :
            base(owner)
        {
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.TabItem;
        }
    }
}
