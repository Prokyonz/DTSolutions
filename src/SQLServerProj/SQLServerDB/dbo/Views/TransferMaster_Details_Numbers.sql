﻿CREATE VIEW dbo.TransferMaster_Details_Numbers
AS
SELECT        TOP (100) PERCENT dbo.TransferDetails.Id, dbo.TransferDetails.TransferMasterId, dbo.TransferMaster.JangadNo, CAST(dbo.TransferMaster.Date AS datetime) AS Date, dbo.TransferMaster.Time, 
                         dbo.TransferMaster.TRansferById, dbo.TransferMaster.CompanyId, dbo.TransferMaster.CharniSizeId, CAST(dbo.TransferDetails.FromCategory AS int) AS FromCategory, dbo.TransferDetails.BranchId, 
                         dbo.TransferDetails.ShapeId, dbo.TransferDetails.Carat, dbo.TransferDetails.Rate, dbo.TransferDetails.Amount, CAST(dbo.TransferDetails.ToCategory AS INT) AS ToCategory, dbo.TransferDetails.ToSizeId, 
                         dbo.TransferDetails.ToBranchId, dbo.TransferDetails.ToNumberIdORKapanId, dbo.TransferDetails.ToCarat, dbo.TransferDetails.ToRate, dbo.TransferDetails.ToAmount, dbo.TransferDetails.FromNumberIdORKapanId, 
                         dbo.TransferMaster.Sr, dbo.TransferDetails.Sr AS TrasnferDetailsSR, dbo.NumberMaster.Name
FROM            dbo.TransferMaster INNER JOIN
                         dbo.TransferDetails ON dbo.TransferMaster.Id = dbo.TransferDetails.TransferMasterId LEFT OUTER JOIN
                         dbo.NumberMaster ON dbo.TransferDetails.ToNumberIdORKapanId = dbo.NumberMaster.Id
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'TransferMaster_Details_Numbers';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'TransferMaster_Details_Numbers';




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[5] 2[33] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TransferMaster"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 214
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "TransferDetails"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 214
               Right = 476
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "NumberMaster"
            Begin Extent = 
               Top = 10
               Left = 708
               Bottom = 140
               Right = 878
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 27
         Width = 284
         Width = 3450
         Width = 3405
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 3285
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'TransferMaster_Details_Numbers';



