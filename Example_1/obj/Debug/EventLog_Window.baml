   M S B A M L   `   `   `  ????G  CMOdule13_OOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MOdule13_OOPMOdule13_OOP  5   	   "    MOdule13_OOP.EventLog_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MOdule13_OOP     5   	     ? Title$  EventLog_Window??5   	   $	??450??6!   $	??800??6.   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $
??733* ?6   ?? 5      $	??67* ?6    ? RowDefinitions 5   
   ?? 5      $	??18* ?6   ?? 5      $
??199* ?6   .+?5   
   ?? -   5         ??Name$ 	ListEvent??5   ?   
???????$??10,10,10,10q?6*   $??1??6R   $??2??6_    ?? View 5      ?? 5      P?5      ?? 5      $??Пользователь??6)    ?? DisplayMemberBinding 6?   ?? *User+?? 5      $-??'Выполняемое действие??6)    6G   ?? *	EventUser+?? 5      $6??0Время выполнения операции??6)    6L   ?? *	EventTime+5      5      ?? 5   
   -   5        $
??Exit??5      $??1??6    $??0??60   6=   5      5       