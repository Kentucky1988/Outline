﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApplication1
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Employee")]
	public partial class DataClassesEmployeeDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Определения метода расширяемости
    partial void OnCreated();
    partial void InsertEmploye(Employe instance);
    partial void UpdateEmploye(Employe instance);
    partial void DeleteEmploye(Employe instance);
    partial void InsertFelling(Felling instance);
    partial void UpdateFelling(Felling instance);
    partial void DeleteFelling(Felling instance);
    partial void InsertForestry(Forestry instance);
    partial void UpdateForestry(Forestry instance);
    partial void DeleteForestry(Forestry instance);
    partial void InsertJournal(Journal instance);
    partial void UpdateJournal(Journal instance);
    partial void DeleteJournal(Journal instance);
    partial void InsertLeshoz(Leshoz instance);
    partial void UpdateLeshoz(Leshoz instance);
    partial void DeleteLeshoz(Leshoz instance);
    partial void InsertPlotList(PlotList instance);
    partial void UpdatePlotList(PlotList instance);
    partial void DeletePlotList(PlotList instance);
    #endregion
		
		public DataClassesEmployeeDataContext() : 
				base(global::WpfApplication1.Properties.Settings.Default.EmployeeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesEmployeeDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesEmployeeDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesEmployeeDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesEmployeeDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Employe> Employe
		{
			get
			{
				return this.GetTable<Employe>();
			}
		}
		
		public System.Data.Linq.Table<Felling> Felling
		{
			get
			{
				return this.GetTable<Felling>();
			}
		}
		
		public System.Data.Linq.Table<Forestry> Forestry
		{
			get
			{
				return this.GetTable<Forestry>();
			}
		}
		
		public System.Data.Linq.Table<Journal> Journal
		{
			get
			{
				return this.GetTable<Journal>();
			}
		}
		
		public System.Data.Linq.Table<Leshoz> Leshoz
		{
			get
			{
				return this.GetTable<Leshoz>();
			}
		}
		
		public System.Data.Linq.Table<PlotList> PlotList
		{
			get
			{
				return this.GetTable<PlotList>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Employe")]
	public partial class Employe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Employe1;
		
		private string _Position;
		
		private EntitySet<PlotList> _PlotList;
		
		private EntitySet<PlotList> _PlotList1;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmploye1Changing(string value);
    partial void OnEmploye1Changed();
    partial void OnPositionChanging(string value);
    partial void OnPositionChanged();
    #endregion
		
		public Employe()
		{
			this._PlotList = new EntitySet<PlotList>(new Action<PlotList>(this.attach_PlotList), new Action<PlotList>(this.detach_PlotList));
			this._PlotList1 = new EntitySet<PlotList>(new Action<PlotList>(this.attach_PlotList1), new Action<PlotList>(this.detach_PlotList1));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Employe", Storage="_Employe1", DbType="NVarChar(30) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Employe1
		{
			get
			{
				return this._Employe1;
			}
			set
			{
				if ((this._Employe1 != value))
				{
					this.OnEmploye1Changing(value);
					this.SendPropertyChanging();
					this._Employe1 = value;
					this.SendPropertyChanged("Employe1");
					this.OnEmploye1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Position", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Position
		{
			get
			{
				return this._Position;
			}
			set
			{
				if ((this._Position != value))
				{
					this.OnPositionChanging(value);
					this.SendPropertyChanging();
					this._Position = value;
					this.SendPropertyChanged("Position");
					this.OnPositionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employe_PlotList", Storage="_PlotList", ThisKey="Employe1", OtherKey="ShotPerformed")]
		public EntitySet<PlotList> PlotList
		{
			get
			{
				return this._PlotList;
			}
			set
			{
				this._PlotList.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employe_PlotList1", Storage="_PlotList1", ThisKey="Employe1", OtherKey="PlanDrew")]
		public EntitySet<PlotList> PlotList1
		{
			get
			{
				return this._PlotList1;
			}
			set
			{
				this._PlotList1.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PlotList(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Employe = this;
		}
		
		private void detach_PlotList(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Employe = null;
		}
		
		private void attach_PlotList1(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Employe1 = this;
		}
		
		private void detach_PlotList1(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Employe1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Felling")]
	public partial class Felling : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Felling1;
		
		private EntitySet<PlotList> _PlotList;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFelling1Changing(string value);
    partial void OnFelling1Changed();
    #endregion
		
		public Felling()
		{
			this._PlotList = new EntitySet<PlotList>(new Action<PlotList>(this.attach_PlotList), new Action<PlotList>(this.detach_PlotList));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Felling", Storage="_Felling1", DbType="NVarChar(30) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Felling1
		{
			get
			{
				return this._Felling1;
			}
			set
			{
				if ((this._Felling1 != value))
				{
					this.OnFelling1Changing(value);
					this.SendPropertyChanging();
					this._Felling1 = value;
					this.SendPropertyChanged("Felling1");
					this.OnFelling1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Felling_PlotList", Storage="_PlotList", ThisKey="Felling1", OtherKey="Felling")]
		public EntitySet<PlotList> PlotList
		{
			get
			{
				return this._PlotList;
			}
			set
			{
				this._PlotList.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PlotList(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Felling1 = this;
		}
		
		private void detach_PlotList(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Felling1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Forestry")]
	public partial class Forestry : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Forestry1;
		
		private string _Leshoz;
		
		private EntitySet<PlotList> _PlotList;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnForestry1Changing(string value);
    partial void OnForestry1Changed();
    partial void OnLeshozChanging(string value);
    partial void OnLeshozChanged();
    #endregion
		
		public Forestry()
		{
			this._PlotList = new EntitySet<PlotList>(new Action<PlotList>(this.attach_PlotList), new Action<PlotList>(this.detach_PlotList));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Forestry", Storage="_Forestry1", DbType="NVarChar(30) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Forestry1
		{
			get
			{
				return this._Forestry1;
			}
			set
			{
				if ((this._Forestry1 != value))
				{
					this.OnForestry1Changing(value);
					this.SendPropertyChanging();
					this._Forestry1 = value;
					this.SendPropertyChanged("Forestry1");
					this.OnForestry1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Leshoz", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Leshoz
		{
			get
			{
				return this._Leshoz;
			}
			set
			{
				if ((this._Leshoz != value))
				{
					this.OnLeshozChanging(value);
					this.SendPropertyChanging();
					this._Leshoz = value;
					this.SendPropertyChanged("Leshoz");
					this.OnLeshozChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Forestry_PlotList", Storage="_PlotList", ThisKey="Forestry1", OtherKey="Forestry")]
		public EntitySet<PlotList> PlotList
		{
			get
			{
				return this._PlotList;
			}
			set
			{
				this._PlotList.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PlotList(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Forestry1 = this;
		}
		
		private void detach_PlotList(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Forestry1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Journal")]
	public partial class Journal : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _Id_PlotList;
		
		private int _Identifier;
		
		private string _Rumb;
		
		private int _Grade;
		
		private int _Minutes;
		
		private decimal _Length;
		
		private EntityRef<PlotList> _PlotList;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnId_PlotListChanging(int value);
    partial void OnId_PlotListChanged();
    partial void OnIdentifierChanging(int value);
    partial void OnIdentifierChanged();
    partial void OnRumbChanging(string value);
    partial void OnRumbChanged();
    partial void OnGradeChanging(int value);
    partial void OnGradeChanged();
    partial void OnMinutesChanging(int value);
    partial void OnMinutesChanged();
    partial void OnLengthChanging(decimal value);
    partial void OnLengthChanged();
    #endregion
		
		public Journal()
		{
			this._PlotList = default(EntityRef<PlotList>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_PlotList", DbType="Int NOT NULL")]
		public int Id_PlotList
		{
			get
			{
				return this._Id_PlotList;
			}
			set
			{
				if ((this._Id_PlotList != value))
				{
					if (this._PlotList.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_PlotListChanging(value);
					this.SendPropertyChanging();
					this._Id_PlotList = value;
					this.SendPropertyChanged("Id_PlotList");
					this.OnId_PlotListChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Identifier", DbType="Int NOT NULL")]
		public int Identifier
		{
			get
			{
				return this._Identifier;
			}
			set
			{
				if ((this._Identifier != value))
				{
					this.OnIdentifierChanging(value);
					this.SendPropertyChanging();
					this._Identifier = value;
					this.SendPropertyChanged("Identifier");
					this.OnIdentifierChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rumb", DbType="NVarChar(4) NOT NULL", CanBeNull=false)]
		public string Rumb
		{
			get
			{
				return this._Rumb;
			}
			set
			{
				if ((this._Rumb != value))
				{
					this.OnRumbChanging(value);
					this.SendPropertyChanging();
					this._Rumb = value;
					this.SendPropertyChanged("Rumb");
					this.OnRumbChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Grade", DbType="Int NOT NULL")]
		public int Grade
		{
			get
			{
				return this._Grade;
			}
			set
			{
				if ((this._Grade != value))
				{
					this.OnGradeChanging(value);
					this.SendPropertyChanging();
					this._Grade = value;
					this.SendPropertyChanged("Grade");
					this.OnGradeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Minutes", DbType="Int NOT NULL")]
		public int Minutes
		{
			get
			{
				return this._Minutes;
			}
			set
			{
				if ((this._Minutes != value))
				{
					this.OnMinutesChanging(value);
					this.SendPropertyChanging();
					this._Minutes = value;
					this.SendPropertyChanged("Minutes");
					this.OnMinutesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Length", DbType="Decimal(5,2) NOT NULL")]
		public decimal Length
		{
			get
			{
				return this._Length;
			}
			set
			{
				if ((this._Length != value))
				{
					this.OnLengthChanging(value);
					this.SendPropertyChanging();
					this._Length = value;
					this.SendPropertyChanged("Length");
					this.OnLengthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PlotList_Journal", Storage="_PlotList", ThisKey="Id_PlotList", OtherKey="Id", IsForeignKey=true)]
		public PlotList PlotList
		{
			get
			{
				return this._PlotList.Entity;
			}
			set
			{
				PlotList previousValue = this._PlotList.Entity;
				if (((previousValue != value) 
							|| (this._PlotList.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PlotList.Entity = null;
						previousValue.Journal.Remove(this);
					}
					this._PlotList.Entity = value;
					if ((value != null))
					{
						value.Journal.Add(this);
						this._Id_PlotList = value.Id;
					}
					else
					{
						this._Id_PlotList = default(int);
					}
					this.SendPropertyChanged("PlotList");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Leshoz")]
	public partial class Leshoz : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Leshoz1;
		
		private EntitySet<PlotList> _PlotList;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLeshoz1Changing(string value);
    partial void OnLeshoz1Changed();
    #endregion
		
		public Leshoz()
		{
			this._PlotList = new EntitySet<PlotList>(new Action<PlotList>(this.attach_PlotList), new Action<PlotList>(this.detach_PlotList));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Leshoz", Storage="_Leshoz1", DbType="NVarChar(30) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Leshoz1
		{
			get
			{
				return this._Leshoz1;
			}
			set
			{
				if ((this._Leshoz1 != value))
				{
					this.OnLeshoz1Changing(value);
					this.SendPropertyChanging();
					this._Leshoz1 = value;
					this.SendPropertyChanged("Leshoz1");
					this.OnLeshoz1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Leshoz_PlotList", Storage="_PlotList", ThisKey="Leshoz1", OtherKey="Leshoz")]
		public EntitySet<PlotList> PlotList
		{
			get
			{
				return this._PlotList;
			}
			set
			{
				this._PlotList.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PlotList(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Leshoz1 = this;
		}
		
		private void detach_PlotList(PlotList entity)
		{
			this.SendPropertyChanging();
			entity.Leshoz1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PlotList")]
	public partial class PlotList : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Leshoz;
		
		private string _Forestry;
		
		private string _Felling;
		
		private int _Kvartal;
		
		private decimal _Vudel;
		
		private int _PointNumber;
		
		private decimal _Area;
		
		private int _Year;
		
		private string _ShotPerformed;
		
		private string _PlanDrew;
		
		private EntitySet<Journal> _Journal;
		
		private EntityRef<Employe> _Employe;
		
		private EntityRef<Employe> _Employe1;
		
		private EntityRef<Felling> _Felling1;
		
		private EntityRef<Forestry> _Forestry1;
		
		private EntityRef<Leshoz> _Leshoz1;
		
    #region Определения метода расширяемости
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnLeshozChanging(string value);
    partial void OnLeshozChanged();
    partial void OnForestryChanging(string value);
    partial void OnForestryChanged();
    partial void OnFellingChanging(string value);
    partial void OnFellingChanged();
    partial void OnKvartalChanging(int value);
    partial void OnKvartalChanged();
    partial void OnVudelChanging(decimal value);
    partial void OnVudelChanged();
    partial void OnPointNumberChanging(int value);
    partial void OnPointNumberChanged();
    partial void OnAreaChanging(decimal value);
    partial void OnAreaChanged();
    partial void OnYearChanging(int value);
    partial void OnYearChanged();
    partial void OnShotPerformedChanging(string value);
    partial void OnShotPerformedChanged();
    partial void OnPlanDrewChanging(string value);
    partial void OnPlanDrewChanged();
    #endregion
		
		public PlotList()
		{
			this._Journal = new EntitySet<Journal>(new Action<Journal>(this.attach_Journal), new Action<Journal>(this.detach_Journal));
			this._Employe = default(EntityRef<Employe>);
			this._Employe1 = default(EntityRef<Employe>);
			this._Felling1 = default(EntityRef<Felling>);
			this._Forestry1 = default(EntityRef<Forestry>);
			this._Leshoz1 = default(EntityRef<Leshoz>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Leshoz", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Leshoz
		{
			get
			{
				return this._Leshoz;
			}
			set
			{
				if ((this._Leshoz != value))
				{
					if (this._Leshoz1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLeshozChanging(value);
					this.SendPropertyChanging();
					this._Leshoz = value;
					this.SendPropertyChanged("Leshoz");
					this.OnLeshozChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Forestry", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Forestry
		{
			get
			{
				return this._Forestry;
			}
			set
			{
				if ((this._Forestry != value))
				{
					if (this._Forestry1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnForestryChanging(value);
					this.SendPropertyChanging();
					this._Forestry = value;
					this.SendPropertyChanged("Forestry");
					this.OnForestryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Felling", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Felling
		{
			get
			{
				return this._Felling;
			}
			set
			{
				if ((this._Felling != value))
				{
					if (this._Felling1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFellingChanging(value);
					this.SendPropertyChanging();
					this._Felling = value;
					this.SendPropertyChanged("Felling");
					this.OnFellingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kvartal", DbType="Int NOT NULL")]
		public int Kvartal
		{
			get
			{
				return this._Kvartal;
			}
			set
			{
				if ((this._Kvartal != value))
				{
					this.OnKvartalChanging(value);
					this.SendPropertyChanging();
					this._Kvartal = value;
					this.SendPropertyChanged("Kvartal");
					this.OnKvartalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vudel", DbType="Decimal(5,2) NOT NULL")]
		public decimal Vudel
		{
			get
			{
				return this._Vudel;
			}
			set
			{
				if ((this._Vudel != value))
				{
					this.OnVudelChanging(value);
					this.SendPropertyChanging();
					this._Vudel = value;
					this.SendPropertyChanged("Vudel");
					this.OnVudelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PointNumber", DbType="Int NOT NULL")]
		public int PointNumber
		{
			get
			{
				return this._PointNumber;
			}
			set
			{
				if ((this._PointNumber != value))
				{
					this.OnPointNumberChanging(value);
					this.SendPropertyChanging();
					this._PointNumber = value;
					this.SendPropertyChanged("PointNumber");
					this.OnPointNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Area", DbType="Decimal(5,2) NOT NULL")]
		public decimal Area
		{
			get
			{
				return this._Area;
			}
			set
			{
				if ((this._Area != value))
				{
					this.OnAreaChanging(value);
					this.SendPropertyChanging();
					this._Area = value;
					this.SendPropertyChanged("Area");
					this.OnAreaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Year", DbType="Int NOT NULL")]
		public int Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this.OnYearChanging(value);
					this.SendPropertyChanging();
					this._Year = value;
					this.SendPropertyChanged("Year");
					this.OnYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShotPerformed", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string ShotPerformed
		{
			get
			{
				return this._ShotPerformed;
			}
			set
			{
				if ((this._ShotPerformed != value))
				{
					if (this._Employe.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnShotPerformedChanging(value);
					this.SendPropertyChanging();
					this._ShotPerformed = value;
					this.SendPropertyChanged("ShotPerformed");
					this.OnShotPerformedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlanDrew", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string PlanDrew
		{
			get
			{
				return this._PlanDrew;
			}
			set
			{
				if ((this._PlanDrew != value))
				{
					if (this._Employe1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPlanDrewChanging(value);
					this.SendPropertyChanging();
					this._PlanDrew = value;
					this.SendPropertyChanged("PlanDrew");
					this.OnPlanDrewChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PlotList_Journal", Storage="_Journal", ThisKey="Id", OtherKey="Id_PlotList")]
		public EntitySet<Journal> Journal
		{
			get
			{
				return this._Journal;
			}
			set
			{
				this._Journal.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employe_PlotList", Storage="_Employe", ThisKey="ShotPerformed", OtherKey="Employe1", IsForeignKey=true)]
		public Employe Employe
		{
			get
			{
				return this._Employe.Entity;
			}
			set
			{
				Employe previousValue = this._Employe.Entity;
				if (((previousValue != value) 
							|| (this._Employe.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employe.Entity = null;
						previousValue.PlotList.Remove(this);
					}
					this._Employe.Entity = value;
					if ((value != null))
					{
						value.PlotList.Add(this);
						this._ShotPerformed = value.Employe1;
					}
					else
					{
						this._ShotPerformed = default(string);
					}
					this.SendPropertyChanged("Employe");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employe_PlotList1", Storage="_Employe1", ThisKey="PlanDrew", OtherKey="Employe1", IsForeignKey=true)]
		public Employe Employe1
		{
			get
			{
				return this._Employe1.Entity;
			}
			set
			{
				Employe previousValue = this._Employe1.Entity;
				if (((previousValue != value) 
							|| (this._Employe1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employe1.Entity = null;
						previousValue.PlotList1.Remove(this);
					}
					this._Employe1.Entity = value;
					if ((value != null))
					{
						value.PlotList1.Add(this);
						this._PlanDrew = value.Employe1;
					}
					else
					{
						this._PlanDrew = default(string);
					}
					this.SendPropertyChanged("Employe1");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Felling_PlotList", Storage="_Felling1", ThisKey="Felling", OtherKey="Felling1", IsForeignKey=true)]
		public Felling Felling1
		{
			get
			{
				return this._Felling1.Entity;
			}
			set
			{
				Felling previousValue = this._Felling1.Entity;
				if (((previousValue != value) 
							|| (this._Felling1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Felling1.Entity = null;
						previousValue.PlotList.Remove(this);
					}
					this._Felling1.Entity = value;
					if ((value != null))
					{
						value.PlotList.Add(this);
						this._Felling = value.Felling1;
					}
					else
					{
						this._Felling = default(string);
					}
					this.SendPropertyChanged("Felling1");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Forestry_PlotList", Storage="_Forestry1", ThisKey="Forestry", OtherKey="Forestry1", IsForeignKey=true)]
		public Forestry Forestry1
		{
			get
			{
				return this._Forestry1.Entity;
			}
			set
			{
				Forestry previousValue = this._Forestry1.Entity;
				if (((previousValue != value) 
							|| (this._Forestry1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Forestry1.Entity = null;
						previousValue.PlotList.Remove(this);
					}
					this._Forestry1.Entity = value;
					if ((value != null))
					{
						value.PlotList.Add(this);
						this._Forestry = value.Forestry1;
					}
					else
					{
						this._Forestry = default(string);
					}
					this.SendPropertyChanged("Forestry1");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Leshoz_PlotList", Storage="_Leshoz1", ThisKey="Leshoz", OtherKey="Leshoz1", IsForeignKey=true)]
		public Leshoz Leshoz1
		{
			get
			{
				return this._Leshoz1.Entity;
			}
			set
			{
				Leshoz previousValue = this._Leshoz1.Entity;
				if (((previousValue != value) 
							|| (this._Leshoz1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Leshoz1.Entity = null;
						previousValue.PlotList.Remove(this);
					}
					this._Leshoz1.Entity = value;
					if ((value != null))
					{
						value.PlotList.Add(this);
						this._Leshoz = value.Leshoz1;
					}
					else
					{
						this._Leshoz = default(string);
					}
					this.SendPropertyChanged("Leshoz1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Journal(Journal entity)
		{
			this.SendPropertyChanging();
			entity.PlotList = this;
		}
		
		private void detach_Journal(Journal entity)
		{
			this.SendPropertyChanging();
			entity.PlotList = null;
		}
	}
}
#pragma warning restore 1591
