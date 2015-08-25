import System
import System.Windows.Forms

def Main() : string 
    import System.Windows.Forms
    import System

    #Create a Form
    dec frm : object = new Form();
    frm.Text = "Ec lang form sample";

    #Create a Label
    dec lbl : object = new Label();
    lbl.AutoSize = true;

    lbl.Text = "This is a form Created in ec";

    #Add lbl to frm and Show frm
    frm.Controls.Add(lbl);
    frm.Show();
end def

Main();

while true
    Application.DoEvents();
end while