'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18408
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection

Namespace nsRanges
	
	<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="Ranges")>  _
	Partial Public Class dcRanges
		Inherits System.Data.Linq.DataContext
		
		Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
		
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub InsertNumSeqMensal(instance As NumSeqMensal)
    End Sub
    Partial Private Sub UpdateNumSeqMensal(instance As NumSeqMensal)
    End Sub
    Partial Private Sub DeleteNumSeqMensal(instance As NumSeqMensal)
    End Sub
    Partial Private Sub InsertRanges(instance As Ranges)
    End Sub
    Partial Private Sub UpdateRanges(instance As Ranges)
    End Sub
    Partial Private Sub DeleteRanges(instance As Ranges)
    End Sub
    Partial Private Sub InsertSrvChk(instance As SrvChk)
    End Sub
    Partial Private Sub UpdateSrvChk(instance As SrvChk)
    End Sub
    Partial Private Sub DeleteSrvChk(instance As SrvChk)
    End Sub
    #End Region
		
		Public Sub New()
			MyBase.New(Global.Geral.My.MySettings.Default.csRanges, mappingSource)
			OnCreated
		End Sub
		
		Public Sub New(ByVal connection As String)
			MyBase.New(connection, mappingSource)
			OnCreated
		End Sub
		
		Public Sub New(ByVal connection As System.Data.IDbConnection)
			MyBase.New(connection, mappingSource)
			OnCreated
		End Sub
		
		Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
			MyBase.New(connection, mappingSource)
			OnCreated
		End Sub
		
		Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
			MyBase.New(connection, mappingSource)
			OnCreated
		End Sub
		
		Public ReadOnly Property NumSeqMensal() As System.Data.Linq.Table(Of NumSeqMensal)
			Get
				Return Me.GetTable(Of NumSeqMensal)
			End Get
		End Property
		
		Public ReadOnly Property Ranges() As System.Data.Linq.Table(Of Ranges)
			Get
				Return Me.GetTable(Of Ranges)
			End Get
		End Property
		
		Public ReadOnly Property SrvChk() As System.Data.Linq.Table(Of SrvChk)
			Get
				Return Me.GetTable(Of SrvChk)
			End Get
		End Property
	End Class
	
	<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.NumSeqMensal")>  _
	Partial Public Class NumSeqMensal
		Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
		
		Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
		
		Private _AnoUlt As Integer
		
		Private _MesUlt As Integer
		
		Private _NumSeqMensal As System.Nullable(Of Integer)
		
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnAnoUltChanging(value As Integer)
    End Sub
    Partial Private Sub OnAnoUltChanged()
    End Sub
    Partial Private Sub OnMesUltChanging(value As Integer)
    End Sub
    Partial Private Sub OnMesUltChanged()
    End Sub
    Partial Private Sub OnNumSeqMensalChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnNumSeqMensalChanged()
    End Sub
    #End Region
		
		Public Sub New()
			MyBase.New
			OnCreated
		End Sub
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_AnoUlt", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
		Public Property AnoUlt() As Integer
			Get
				Return Me._AnoUlt
			End Get
			Set
				If ((Me._AnoUlt = value)  _
							= false) Then
					Me.OnAnoUltChanging(value)
					Me.SendPropertyChanging
					Me._AnoUlt = value
					Me.SendPropertyChanged("AnoUlt")
					Me.OnAnoUltChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_MesUlt", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
		Public Property MesUlt() As Integer
			Get
				Return Me._MesUlt
			End Get
			Set
				If ((Me._MesUlt = value)  _
							= false) Then
					Me.OnMesUltChanging(value)
					Me.SendPropertyChanging
					Me._MesUlt = value
					Me.SendPropertyChanged("MesUlt")
					Me.OnMesUltChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NumSeqMensal", DbType:="Int")>  _
		Public Property NumSeqMensal() As System.Nullable(Of Integer)
			Get
				Return Me._NumSeqMensal
			End Get
			Set
				If (Me._NumSeqMensal.Equals(value) = false) Then
					Me.OnNumSeqMensalChanging(value)
					Me.SendPropertyChanging
					Me._NumSeqMensal = value
					Me.SendPropertyChanged("NumSeqMensal")
					Me.OnNumSeqMensalChanged
				End If
			End Set
		End Property
		
		Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
		
		Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
		
		Protected Overridable Sub SendPropertyChanging()
			If ((Me.PropertyChangingEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
			End If
		End Sub
		
		Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
			If ((Me.PropertyChangedEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
			End If
		End Sub
	End Class
	
	<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Ranges")>  _
	Partial Public Class Ranges
		Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
		
		Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
		
		Private _RecNum As Integer
		
		Private _DensMin As System.Nullable(Of Double)
		
		Private _DensMed As System.Nullable(Of Double)
		
		Private _DensMax As System.Nullable(Of Double)
		
		Private _SolMin As System.Nullable(Of Double)
		
		Private _SolMed As System.Nullable(Of Double)
		
		Private _SolMax As System.Nullable(Of Double)
		
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnRecNumChanging(value As Integer)
    End Sub
    Partial Private Sub OnRecNumChanged()
    End Sub
    Partial Private Sub OnDensMinChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub OnDensMinChanged()
    End Sub
    Partial Private Sub OnDensMedChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub OnDensMedChanged()
    End Sub
    Partial Private Sub OnDensMaxChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub OnDensMaxChanged()
    End Sub
    Partial Private Sub OnSolMinChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub OnSolMinChanged()
    End Sub
    Partial Private Sub OnSolMedChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub OnSolMedChanged()
    End Sub
    Partial Private Sub OnSolMaxChanging(value As System.Nullable(Of Double))
    End Sub
    Partial Private Sub OnSolMaxChanged()
    End Sub
    #End Region
		
		Public Sub New()
			MyBase.New
			OnCreated
		End Sub
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RecNum", DbType:="Int NOT NULL", IsPrimaryKey:=true)>  _
		Public Property RecNum() As Integer
			Get
				Return Me._RecNum
			End Get
			Set
				If ((Me._RecNum = value)  _
							= false) Then
					Me.OnRecNumChanging(value)
					Me.SendPropertyChanging
					Me._RecNum = value
					Me.SendPropertyChanged("RecNum")
					Me.OnRecNumChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DensMin", DbType:="Float")>  _
		Public Property DensMin() As System.Nullable(Of Double)
			Get
				Return Me._DensMin
			End Get
			Set
				If (Me._DensMin.Equals(value) = false) Then
					Me.OnDensMinChanging(value)
					Me.SendPropertyChanging
					Me._DensMin = value
					Me.SendPropertyChanged("DensMin")
					Me.OnDensMinChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DensMed", DbType:="Float")>  _
		Public Property DensMed() As System.Nullable(Of Double)
			Get
				Return Me._DensMed
			End Get
			Set
				If (Me._DensMed.Equals(value) = false) Then
					Me.OnDensMedChanging(value)
					Me.SendPropertyChanging
					Me._DensMed = value
					Me.SendPropertyChanged("DensMed")
					Me.OnDensMedChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DensMax", DbType:="Float")>  _
		Public Property DensMax() As System.Nullable(Of Double)
			Get
				Return Me._DensMax
			End Get
			Set
				If (Me._DensMax.Equals(value) = false) Then
					Me.OnDensMaxChanging(value)
					Me.SendPropertyChanging
					Me._DensMax = value
					Me.SendPropertyChanged("DensMax")
					Me.OnDensMaxChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SolMin", DbType:="Float")>  _
		Public Property SolMin() As System.Nullable(Of Double)
			Get
				Return Me._SolMin
			End Get
			Set
				If (Me._SolMin.Equals(value) = false) Then
					Me.OnSolMinChanging(value)
					Me.SendPropertyChanging
					Me._SolMin = value
					Me.SendPropertyChanged("SolMin")
					Me.OnSolMinChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SolMed", DbType:="Float")>  _
		Public Property SolMed() As System.Nullable(Of Double)
			Get
				Return Me._SolMed
			End Get
			Set
				If (Me._SolMed.Equals(value) = false) Then
					Me.OnSolMedChanging(value)
					Me.SendPropertyChanging
					Me._SolMed = value
					Me.SendPropertyChanged("SolMed")
					Me.OnSolMedChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SolMax", DbType:="Float")>  _
		Public Property SolMax() As System.Nullable(Of Double)
			Get
				Return Me._SolMax
			End Get
			Set
				If (Me._SolMax.Equals(value) = false) Then
					Me.OnSolMaxChanging(value)
					Me.SendPropertyChanging
					Me._SolMax = value
					Me.SendPropertyChanged("SolMax")
					Me.OnSolMaxChanged
				End If
			End Set
		End Property
		
		Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
		
		Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
		
		Protected Overridable Sub SendPropertyChanging()
			If ((Me.PropertyChangingEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
			End If
		End Sub
		
		Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
			If ((Me.PropertyChangedEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
			End If
		End Sub
	End Class
	
	<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.SrvChk")>  _
	Partial Public Class SrvChk
		Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
		
		Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
		
		Private _Item As String
		
		Private _ContaD As System.Nullable(Of Integer)
		
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnItemChanging(value As String)
    End Sub
    Partial Private Sub OnItemChanged()
    End Sub
    Partial Private Sub OnContaDChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnContaDChanged()
    End Sub
    #End Region
		
		Public Sub New()
			MyBase.New
			OnCreated
		End Sub
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Item", DbType:="NVarChar(20) NOT NULL", CanBeNull:=false, IsPrimaryKey:=true)>  _
		Public Property Item() As String
			Get
				Return Me._Item
			End Get
			Set
				If (String.Equals(Me._Item, value) = false) Then
					Me.OnItemChanging(value)
					Me.SendPropertyChanging
					Me._Item = value
					Me.SendPropertyChanged("Item")
					Me.OnItemChanged
				End If
			End Set
		End Property
		
		<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ContaD", DbType:="Int")>  _
		Public Property ContaD() As System.Nullable(Of Integer)
			Get
				Return Me._ContaD
			End Get
			Set
				If (Me._ContaD.Equals(value) = false) Then
					Me.OnContaDChanging(value)
					Me.SendPropertyChanging
					Me._ContaD = value
					Me.SendPropertyChanged("ContaD")
					Me.OnContaDChanged
				End If
			End Set
		End Property
		
		Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
		
		Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
		
		Protected Overridable Sub SendPropertyChanging()
			If ((Me.PropertyChangingEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
			End If
		End Sub
		
		Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
			If ((Me.PropertyChangedEvent Is Nothing)  _
						= false) Then
				RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
			End If
		End Sub
	End Class
End Namespace
