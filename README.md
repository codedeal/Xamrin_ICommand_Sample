# Xamrin_ICommand_Sample

In the Model-View-ViewModel (MVVM) architecture, data bindings are defined between properties in the ViewModel, which is
generally a class that derives from INotifyPropertyChanged, and properties in the View, which is generally the XAML file. 

The commanding interface provides an alternative approach to implementing commands that is 
much better suited to the MVVM architecture. The ViewModel itself can contain commands, which are methods 
that are executed in reaction to a specific activity in the View such as a Button click. Data bindings 
are defined between these commands and the Button.

To allow a data binding between a Button and a ViewModel, the Button defines two properties:

Command of type ICommand
CommandParameter of type Object
