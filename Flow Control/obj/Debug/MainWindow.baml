   M S B A M L   `   `   `  ????W  SIntel® ARC™ Game Enhancer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Flow_ControlFlow_Control  5   	   !clr-namespace:InteropInterop  5   	       Flow_Control.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Flow_Control     5   	   )interopclr-namespace:Interop     5   	   -   5           Interop.WindowBlur    	IsEnabled  . 
??????  ? AllowsTransparency .  ? WindowStyle$
 None=?5   	    ? 
ResizeMode$ CanMinimize=?5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$" Intel® ARC™ Game Enhancer??5   	   $	??720??6+   $
??1250??68   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$	 -10q?6   .??5      ?? $??1q?6   ???	#A0050d23$??0q?68    ?? Padding$ 0q?6C   ._?5   
   ? .+?5      ]? $??0,0,0,0q?6   ??. .+?5      ?? -   5        $??TopBarStackPanel??5      $	??Top=?65   $??40??6J   	 ?? Orientation$	 
Horizontal=?6V   .+?5      ??    SecundaryBackgroundColor#???   6   ._?5      ]? -   5        $??TopBarDockPanel??5   $   ??.  ??6Q   ?? *ActualWidth+
 ?? RelativeSource
 ?? *FindAncestor+ ?? AncestorType" ??.+?5      ?? $
??Left=?6(   
??????? ?? TextAlignment$ Center=?6U   $??Center=?6l   $
??20.5(?6?   $??10,0,0,0q?6?   $C??=pack://application:,,,/Assets/Fonts/#IntelOne Display Regular)?6?   Intel® ARC™ Game Enhancer6  ?? 5      $
??Left=?6(   
???????$
??20.5(?6U   $??5,0,0,0q?6e   $??Center=?6v   $ Center=?6?   $C??=pack://application:,,,/Assets/Fonts/#IntelOne Display Regular)?6?   -6?   ?? 5      -   5        $??Title??5   (   $
??Left=?65   
???????$
??20.5(?6b   $??5,0,0,0q?6r   $??Center=?6?   $ Center=?6?   $C??=pack://application:,,,/Assets/Fonts/#IntelOne Display Regular)?6?   test6  ?? 5      -   5        $??Right=?5   (   ???	#FF878787$??32(?6V   $??50??6d   $??0,-7,0,0q?6o   $	??⨯??6?    ? Cursor$
 Hand??6?   $ Center=?6?   6?   ?? 5      -   5        $??Right=?5   (   ???	#FF878787$??25(?6V   $??50??6d   $??0,-5,0,0q?6o   $
??🗕??6?   $
 Hand??6?   $ Center=?6?   6?   5      5       5!      ?? 5"      $
??Left=?6   $??62??6/     PrimaryBackgroundColor#???  6:   ._?5#      ?? $	 Vertical=?6!   .+?5$      	? -   5         	?Name$ rdDXVK??5$   &    d? 	IsChecked$
 TrueY?66   $??DXVK Improvements??6G     MenuRadioButtonStyle#???  6c    	 speed
 ? Tag# ?  6?   $??50??6?   $??60??6?   $??0,1,0,0q?6?    ? ToolTip$ DXVK Improvements??6?   	? 5%      -   5        $ rdGamePatch??5%   &   $ FalseY?6;   $??Game Patches??6M   #???  6d    	 patch# ?  6?   $??50??6?   $??60??6?   $??0,1,0,0q?6?   $ Game Patches??6?   5&      5'       ? 5(      -	   5          ?Name$ PagesNavigation??5(        ? NavigationUIVisibility$ Hidden=?61   5+      5,      5-      5.      5/      