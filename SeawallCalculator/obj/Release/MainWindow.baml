   M S B A M L   `   `   `  ���� L  HSeawallCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SeawallCalculatorSeawallCalculator  "    SeawallCalculator.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  +localclr-namespace:SeawallCalculator    � Title$  Seawall Calculator-V0.0��$	��800��$	��800��
�����_� � DataContext !   SeawallCalculator.ModelView   � 	Resources +  %SeawallCalculator.VisibilityConverter   VisibilityConverter��%   &	          .���  � RowDefinitions �� $
��Auto ��� $
��Auto �.+�o� 
������ $��0��.@�m� $
��File��.@�m� $	��New��m� $
��Open�� m� Command �� *OpenFileButton+m� $
��Save�� �� *SaveFileButton+�� 
�����_�$
��Auto��$
��Auto��$��0,18,-0.4,-18.8q�$��2��.@��� $��Wall Analysis��$
��Auto��.��� -    �Name$ WallPageGrid��$��0,0,0,0q�
�����_� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� �� .+��� $��0��$��0�� �� Orientation$ Vertical=�.+��� $��Wall Analysis��$��20(�
���   �$��20,20,10,10q�$
��Bold"��� $��0��$��0��$ Vertical=�.+��� $��Wall Analysis��$��20(�
���   �$��20,20,10,10q�$
��Bold"��� $ 
Horizontal=�.+��� $��Project��$��16(�
���   �$��	20,0,20,0q�$
��Bold"��� -    ��Name$ Project_input��$��80��$��0,0,0,0q����� *ProjectName+	 �� Mode$	 TwoWay=��� $��Engineer��$��16(�
���   �$��	20,0,20,0q�$
��Bold"��� -   $ Engineer_input��$��80��$��0,0,0,0q����� *EngineerName+$	 TwoWay=��� $��Input Variables��$��16(�$
��Bold"�$��1��$��0��$��	20,0,0,20q��� $ 
Horizontal=�$��2��$��0��.+��� $ Vertical=�.+��� $��Coastline Properties��$��12(�$
��Bold"�$��
20,0,20,10q��� $��Ground Elevation��$��12(�$��20,0,5,5q��� $��Water level behind wall��$��12(�$��20,0,5,5q��� $"��Water level in front of wall��$��12(�$��20,0,5,5q��� $��Mudline Slope��$��12(�$��20,0,5,5q��� $��Landside Slope ��$��12(�$��20,0,5,5q��� $��Mudline Depth��$��12(�$��	20,0,5,10q��� $��Piling��$��12(�$
��Bold"�$��	20,0,10,0q��� $��Top of Pile��$��12(�$��20,0,5,3q��� $��Piles Spacing��$��12(�$��20,0,5,3q��� $$��Lateral Capacity of King Piles��$��12(�$��20,0,5,3q��� $��Slope of Battered Piles��$��12(�$��	20,0,5,10q��� $��Wall Properties��$��12(�$
��Bold"�$��	20,0,10,3q��� $��Panel Thickness��$��12(�$��20,0,5,3q��� $��Safety Factor��$��12(�$��	20,0,5,10q��� $��Soil Properties��$��12(�$
��Bold"�$��	20,0,10,0q��� $��Soil Density��$��12(�$��20,0,5,3q��� $��Saturated Soil Density��$��12(�$��20,0,5,3q��� $��Active Friction Angle��$��12(�$��20,0,5,3q��� $��Passive Friction Angle��$��12(�$��20,0,5,3q��� $!��Soil to Wall Friction Angle��$��12(�$��20,0,5,3q��� $��Live Surcharge��$��12(�$��20,0,5,3q��� $ Vertical=�.+��� -   $ GroundElevationInput��$��75��$��	0,25,20,3q����� *GroundElevation+$	 TwoWay=��� -   $ GroundWaterDepthInput��$��75��$��0,0,20,3q����� *GroundWaterDepth+$	 TwoWay=��� -   $ OpenWaterLevelInput��$��75��$��0,0,20,3q����� *OpenWaterLevel+$	 TwoWay=��� -   $ MudlineSlopeInput��$��75��$��0,0,20,3q����� *MudlineSlope+$	 TwoWay=��� -   $ LandslideSlopeInput��$��75��$��0,0,20,3q����� *LandslideSlope+$	 TwoWay=��� -	   $ MudlineDepthInput��$��75��$��	0,0,20,20q����� *MudlineDepth+$	 TwoWay=��� -
   $ TopofPileInput��$��75��$��0,0,20,3q����� *	TopOfPile+$	 TwoWay=��� -   $ PilespacingInput��$��75��$��0,0,20,3q����� *PilesSpacing+$	 TwoWay=��� -   $ LateralPileCapacityInput��$��75��$��0,0,20,3q����� *LateralCapacityKingPiles+$	 TwoWay=��� -   $ SlopeBatteredPilesInput��$��75��$��	0,0,20,25q����� *SlopeBatteredPiles+$	 TwoWay=��� -   $ PanelThicknessInput��$��75��$��0,0,20,3q����� *PanelThickness+$	 TwoWay=��� -   $ SafetyFactorInput��$��75��$��	0,0,20,20q����� *SafetyFactor+$	 TwoWay=��� -   $ SoilDensityInput��$��75��$��0,0,20,3q����� *SoilDensity+$	 TwoWay=��� -   $ SaturatedSoilDensityInput��$��75��$��0,0,20,3q����� *SaturatedSoilDensity+$	 TwoWay=��� -   $ ActiveFrictionAngleInput��$��75��$��0,0,20,3q����� *ActiveFrictionAngle+$	 TwoWay=��� -   $ PassiveFrictionAngleInput��$��75��$��0,0,20,3q����� *PassiveFrictionAngle+$	 TwoWay=��� -   $ SoilToWallFrictionAngle��$��75��$��0,0,20,3q����� *SoilToWallFrictionAngle+$	 TwoWay=��� -   $ LiveSurcharge��$��75��$��0,0,20,3q����� *LiveSurcharge+$	 TwoWay=��� $ Vertical=�.+��� $�� ��$��12(�$
��Bold"�$��
20,0,20,10q��� $��ft��$��12(�$��20,0,5,5q��� $��ft below Ground��$��12(�$��20,0,5,5q��� $��ft below Ground��$��12(�$��20,0,5,5q��� $��	Downward+��$��12(�$��20,0,5,5q��� $��Upward+��$��12(�$��20,0,5,5q��� $��ft below Ground��$��12(�$��	20,0,5,10q��� $�� ��$��12(�$
��Bold"�$��	20,0,10,0q��� $��ft below ground��$��12(�$��20,0,5,3q��� $��ft��$��12(�$��20,0,5,3q��� $	��Kip��$��12(�$��20,0,5,3q��� $��in/ft��$��12(�$��	20,0,5,10q��� $�� ��$��12(�$
��Bold"�$��	20,0,10,3q��� $��in��$��12(�$��20,0,5,3q��� $��Unitless��$��12(�$��	20,0,5,10q��� $�� ��$��12(�$
��Bold"�$��	20,0,10,0q��� $	��pcf��$��12(�$��20,0,5,3q��� $	��pcf��$��12(�$��20,0,5,3q��� $	��Deg��$��12(�$��20,0,5,3q��� $	��Deg��$��12(�$��20,0,5,3q��� $	��Deg��$��12(�$��20,0,5,3q��� $	��psf��$��12(�$��	20,0,5,20q��� $ Vertical=�$��3��$��0��.+��� $ 
Horizontal=�.+��� $��
Cantilever��$��80,0,0,0q��� -   
 ��Name$
 CheckBoxCantilever��$��40,0,0,0q� d� 	IsChecked �� *isCantilever+$	 TwoWay=��� $ 
Horizontal=�.+��� -    ��Name$ ExecuteAnalysisButton��$��Analyze��$��80��$	��400��$��46,20,200,0q�$	��Hai������ *WallAnalyzeButton+�� -   $ DrawWallButton��$��	Draw Wall��$��80��$	��400��$��-300,20,0,0q����� *DrawWallButton+�� -   $ GenerateReportButton��$��Report��$	��100��$	��400��$��0,20,200,30q�$	��Pon������ *WallReportButton+{��� *EnableReportButton+�� $ Vertical=�$��2��$��1��.+��� $ 
Horizontal=�.+��� $ Vertical=�.+��� $��Analysis Results��$��16(�$
��Bold"�$��1��$��0��$��20,0,0,5q��� $��Lateral Force on Cap��$��20,0,0,5q��� $��
Max. Shear��$��20,0,0,5q��� $��Max. Moment��$��20,0,0,5q��� $"��Axial Force in Battered Pile��$��20,0,0,5q��� $��Axial Force in King Pile��$��20,0,0,5q��� $��Actual Wall Penetration��$��20,0,0,5q��� $ Vertical=�.+��� $��5,25,0,0q�$��75������ *LateralForceOnCap+$	 TwoWay=��� $��5,5,0,0q�$��75������ *MaxWallShear+$	 TwoWay=��� $��5,5,0,0q�$��75������ *MaxWallMoment+$	 TwoWay=��� $��5,5,0,0q�$��75������ *AxialForceinBatteredPile+$	 TwoWay=��� $��5,5,0,0q�$��75������ *AxialForceinKingPile+$	 TwoWay=��� $��5,5,0,0q�$��75������ *ActualWallPenetration+$	 TwoWay=��� $ Vertical=�.+��� $��lb/ft��$��0,25,0,0q��� $��lb*ft/ft��$��0,5,0,0q��� $��lb*ft/ft��$��0,5,0,0q��� $	��kip��$��0,5,0,0q��� $	��kip��$��0,5,0,0q��� $��ft��$��0,5,0,0q�  OxyPlot.Wpf.Plot     Title$ Wall Load Distribution��$	��400��$	��300��
�������$��	20,0,0,30q�   Series   OxyPlot.Wpf.LineSeries    OxyPlot.Wpf.Series   Title$  Shear/Max Shear������ *WallShearSeries+  $  Moment/Max Moment������ *WallMomentSeries+�� $��Wall Diagram��{��� *EnableWallDiagramTab+.��� 
�����_�.+��� $	��500��$	��600��$��stretch=�$��Stretch=�
�������.+��� 	 �� X1$ 0��	 �� Y1$	 -80��	 �� X2$ 0��	 �� Y2$
 1000��
���   �$��2��$��300,100,10,10q� �� StrokeDashArray$	 2 2R��� $��20��$	��300��
���   �$��1��
�������$��291,100,10,10q��� $��40��$��20��
���   �$��1��
�������$��291,80,10,10q��� $ 0��$	 290��
��� � �$��	0,0,10,10q�$��6�� �� * DiagramGroundLevelElevation_Y2+$	 TwoWay=� �� *DiagramGroundLevel_Y1+$	 TwoWay=��� $��Ground Elevation��
 �� Top �� *GroundElevationTagCoordinate+$	 TwoWay=��� ���� *GroundElevationValue+$	 TwoWay=� �� * GroundElevationValueCoordinate+$	 TwoWay=��� $ 0��$	 290��
����  �$��2��$��	0,0,10,10q�$	 2 2R� �� * DiagramGroundWaterElevation_Y1+$	 TwoWay=� �� * DiagramGroundWaterElevation_Y2+$	 TwoWay=��� $��Water behind wall�� �� *#!GroundWaterElevationTagCoordinate+$	 TwoWay=��� ���� *GroundWaterElevationValue+$	 TwoWay=� �� *%#GroundWaterElevationValueCoordinate+$	 TwoWay=��� $ 0��$	 280��
����  �$��6��$��315,0,10,10q� �� *DiagramOpenWaterElevation_Y1+$	 TwoWay=� �� *DiagramOpenWaterElevation_Y2+$	 TwoWay=��� $��Water in front of wall �� �� Left$	 350�� �� *!OpenWaterElevationTagCoordinate+$	 TwoWay=��� $	 350������ *OpenWaterElevationValue+$	 TwoWay=� �� *#!OpenWaterElevationValueCoordinate+$	 TwoWay=��� $ 0��$	 280��
���**��$��6��$��
315,50,0,0q� �� *DiagramMudlineElevation_Y1+$	 TwoWay=� �� *DiagramMudlineElevation_Y2+$	 TwoWay=��� $��Mudline Elevation�� �� Bottom$	 130��$	 350���� $	 120��$	 350������ *MudlineElevationValue+$	 TwoWay=��� $��Wall Min Embedment��$	 110��$	 180���� $	 100��$	 180������ *ActualWallPenetration+$	 TwoWay=��� $��Cap Analysis��.��� 
�����_� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��	Cap Input��$��20(�$
��Bold"�$��40,10,10,100q��� $ 
Horizontal=�.+��� $��Number of Spans��$��	40,60,0,0q�$��14(�$
��Bold"��� -    ��Name$ SpanComboBox��$��50��$��20��$��20q� �� Text$ 1�� �� SelectedItem �� *NumberOfSpans+$	 TwoWay=�.@��� $��1���� $��2���� $��3���� $��4���� $��5���� $ 
Horizontal=�.+��� $��Support Condition��$��	40,90,0,0q�$��14(�$
��Bold"��� -   $ SupportComboBox��$��70��$��20��$��
12,60,20,0q�$ Pinned�� �� *SupportCondition+$	 TwoWay=�.@��� $��Pinned���� $��Fixed���� $��1��$ 
Horizontal=�.+��� $ 
Horizontal=�.+��� $ Vertical=�.+��� $
��Span��$��	30,20,0,5q�$��14(�$
��Bold"��� $��
Beam Width��$��30,0,0,5q�$��14(�$
��Bold"��� $��Beam Height��$��30,0,0,5q�$��14(�$
��Bold"��� $��Distributed Load��$��30,0,0,5q�$��14(�$
��Bold"��� $��
Point Load��$��30,0,0,5q�$��14(�$
��Bold"��� $��Point Load Location��$��30,0,0,5q�$��14(�$
��Bold"��� $ Vertical=�.+��� $��Span 1��$��0,0,0,8q��� $��0,0,0,5q����� *SpanLength1+$	 TwoWay=��� $��0,0,0,5q����� *
BeamWidth1+$	 TwoWay=��� $��0,0,0,5q����� *BeamHeight1+$	 TwoWay=��� $��0,0,0,5q����� *	DistLoad1+$	 TwoWay=��� $��0,0,0,5q����� *
PointLoad1+$	 TwoWay=��� $��0,0,0,5q����� *PointLoadLocation1+$	 TwoWay=��� $ Vertical=�.+��� $��Span 2��$��0,0,0,8q�y��� *VisibilitySpanTwo+$	 TwoWay=� �� 	Converter# [  �� $��0,0,0,5q����� *SpanLength2+$	 TwoWay=�y��� *VisibilitySpanTwo+$	 TwoWay=�# [  �� $��0,0,0,5q����� *
BeamWidth2+$	 TwoWay=�y��� *VisibilitySpanTwo+$	 TwoWay=�# [  �� $��0,0,0,5q����� *BeamHeight2+$	 TwoWay=�y��� *VisibilitySpanTwo+$	 TwoWay=�# [  �� $��0,0,0,5q����� *	DistLoad2+$	 TwoWay=�y��� *VisibilitySpanTwo+$	 TwoWay=�# [  �� $��0,0,0,5q����� *
PointLoad2+$	 TwoWay=�y��� *VisibilitySpanTwo+$	 TwoWay=�# [  �� $��0,0,0,5q����� *PointLoadLocation2+$	 TwoWay=�y��� *VisibilitySpanTwo+$	 TwoWay=�# [  �� $ Vertical=�.+��� $��Span 3��$��0,0,0,8q�y��� *VisibilitySpanThree+$	 TwoWay=�# [  �� $��0,0,0,5q����� *SpanLength3+$	 TwoWay=�y��� *VisibilitySpanThree+$	 TwoWay=�# [  �� $��0,0,0,5q����� *
BeamWidth3+$	 TwoWay=�y��� *VisibilitySpanThree+$	 TwoWay=�# [  �� $��0,0,0,5q����� *BeamHeight3+$	 TwoWay=�y��� *VisibilitySpanThree+$	 TwoWay=�# [  �� $��0,0,0,5q����� *	DistLoad3+$	 TwoWay=�y��� *VisibilitySpanThree+$	 TwoWay=�# [  �� $��0,0,0,5q����� *
PointLoad3+$	 TwoWay=�y��� *VisibilitySpanThree+$	 TwoWay=�# [  �� $��0,0,0,5q����� *PointLoadLocation3+$	 TwoWay=�y��� *VisibilitySpanThree+$	 TwoWay=�# [  �� $ Vertical=�.+��� $��Span 4��$��0,0,0,8q�y��� *VisibilitySpanFour+$	 TwoWay=�# [  �� $��0,0,0,5q����� *SpanLength4+$	 TwoWay=�y��� *VisibilitySpanFour+$	 TwoWay=�# [  �� $��0,0,0,5q����� *
BeamWidth4+$	 TwoWay=�y��� *VisibilitySpanFour+$	 TwoWay=�# [  �� $��0,0,0,5q����� *BeamHeight4+$	 TwoWay=�y��� *VisibilitySpanFour+$	 TwoWay=�# [  �� $��0,0,0,5q����� *	DistLoad4+$	 TwoWay=�y��� *VisibilitySpanFour+$	 TwoWay=�# [  �� $��0,0,0,5q����� *
PointLoad4+$	 TwoWay=�y��� *VisibilitySpanFour+$	 TwoWay=�# [  �� $��0,0,0,5q����� *PointLoadLocation4+$	 TwoWay=�y��� *VisibilitySpanFour+$	 TwoWay=�# [  �� $ Vertical=�.+��� $��Span 5��$��0,0,0,8q�y��� *VisibilitySpanFive+$	 TwoWay=�# [  �� $��0,0,0,5q����� *SpanLength5+$	 TwoWay=�y��� *VisibilitySpanFive+$	 TwoWay=�# [  �� $��0,0,0,5q����� *
BeamWidth5+$	 TwoWay=�y��� *VisibilitySpanFive+$	 TwoWay=�# [  �� $��0,0,0,5q����� *BeamHeight5+$	 TwoWay=�y��� *VisibilitySpanFive+$	 TwoWay=�# [  �� $��0,0,0,5q����� *	DistLoad5+$	 TwoWay=�y��� *VisibilitySpanFive+$	 TwoWay=�# [  �� $��0,0,0,5q����� *
PointLoad5+$	 TwoWay=�y��� *VisibilitySpanFive+$	 TwoWay=�# [  �� $��0,0,0,5q����� *PointLoadLoacation5+$	 TwoWay=�y��� *VisibilitySpanFive+$	 TwoWay=�# [  �� $ Vertical=�.+��� $��
Max Moment��$��	40,20,0,0q��� $��	Max Shear��$��40,5,0,0q��� $ Vertical=�$��20,0,0,0q�.+��� $ 
Horizontal=�.+��� $��Span 1���� $��Span 2��$��10,0,0,5q��� $��Span 3��$��10,0,0,0q��� $��Span 4��$��10,0,0,0q��� $��Span 5��$��10,0,0,0q��� $ 
Horizontal=�.+��� $��MSpan1���� $��MSpan2��$��10,0,0,5q��� $��MSpan3��$��10,0,0,5q��� $��MSpan4��$��10,0,0,5q��� $��MSpan5��$��10,0,0,5q��� $ 
Horizontal=�.+��� $��VSpan1���� $��VSpan2��$��10,0,0,0q��� $��VSpan3��$��10,0,0,0q��� $��VSpan4��$��10,0,0,0q��� $��VSpan5��$��10,0,0,0q��� $ 
Horizontal=�$��2��$��	30,50,0,0q�.+��� -   $ CapAnalyzeButton��$��Analyze��$	��100��$	��400��$	��100��