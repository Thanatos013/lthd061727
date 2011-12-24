﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaroSocialNetwork
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ASPNETDB")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLocation(Location instance);
    partial void UpdateLocation(Location instance);
    partial void DeleteLocation(Location instance);
    partial void InsertLocationCategory(LocationCategory instance);
    partial void UpdateLocationCategory(LocationCategory instance);
    partial void DeleteLocationCategory(LocationCategory instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ASPNETDBConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Location> Locations
		{
			get
			{
				return this.GetTable<Location>();
			}
		}
		
		public System.Data.Linq.Table<LocationCategory> LocationCategories
		{
			get
			{
				return this.GetTable<LocationCategory>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Location")]
	public partial class Location : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _LocationID;
		
		private string _Name;
		
		private string _Location1;
		
		private System.Nullable<double> _Longitude;
		
		private System.Nullable<double> _Latitude;
		
		private string _Note;
		
		private System.Nullable<System.Guid> _CategoryID;
		
		private EntityRef<LocationCategory> _LocationCategory;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLocationIDChanging(System.Guid value);
    partial void OnLocationIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLocation1Changing(string value);
    partial void OnLocation1Changed();
    partial void OnLongitudeChanging(System.Nullable<double> value);
    partial void OnLongitudeChanged();
    partial void OnLatitudeChanging(System.Nullable<double> value);
    partial void OnLatitudeChanged();
    partial void OnNoteChanging(string value);
    partial void OnNoteChanged();
    partial void OnCategoryIDChanging(System.Nullable<System.Guid> value);
    partial void OnCategoryIDChanged();
    #endregion
		
		public Location()
		{
			this._LocationCategory = default(EntityRef<LocationCategory>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LocationID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid LocationID
		{
			get
			{
				return this._LocationID;
			}
			set
			{
				if ((this._LocationID != value))
				{
					this.OnLocationIDChanging(value);
					this.SendPropertyChanging();
					this._LocationID = value;
					this.SendPropertyChanged("LocationID");
					this.OnLocationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Location", Storage="_Location1", DbType="NVarChar(MAX)")]
		public string Location1
		{
			get
			{
				return this._Location1;
			}
			set
			{
				if ((this._Location1 != value))
				{
					this.OnLocation1Changing(value);
					this.SendPropertyChanging();
					this._Location1 = value;
					this.SendPropertyChanged("Location1");
					this.OnLocation1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Longitude", DbType="Float")]
		public System.Nullable<double> Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				if ((this._Longitude != value))
				{
					this.OnLongitudeChanging(value);
					this.SendPropertyChanging();
					this._Longitude = value;
					this.SendPropertyChanged("Longitude");
					this.OnLongitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Latitude", DbType="Float")]
		public System.Nullable<double> Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				if ((this._Latitude != value))
				{
					this.OnLatitudeChanging(value);
					this.SendPropertyChanging();
					this._Latitude = value;
					this.SendPropertyChanged("Latitude");
					this.OnLatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Note", DbType="NVarChar(MAX)")]
		public string Note
		{
			get
			{
				return this._Note;
			}
			set
			{
				if ((this._Note != value))
				{
					this.OnNoteChanging(value);
					this.SendPropertyChanging();
					this._Note = value;
					this.SendPropertyChanged("Note");
					this.OnNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryID", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				if ((this._CategoryID != value))
				{
					if (this._LocationCategory.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._CategoryID = value;
					this.SendPropertyChanged("CategoryID");
					this.OnCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LocationCategory_Location", Storage="_LocationCategory", ThisKey="CategoryID", OtherKey="CategoryID", IsForeignKey=true, DeleteRule="CASCADE")]
		public LocationCategory LocationCategory
		{
			get
			{
				return this._LocationCategory.Entity;
			}
			set
			{
				LocationCategory previousValue = this._LocationCategory.Entity;
				if (((previousValue != value) 
							|| (this._LocationCategory.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LocationCategory.Entity = null;
						previousValue.Locations.Remove(this);
					}
					this._LocationCategory.Entity = value;
					if ((value != null))
					{
						value.Locations.Add(this);
						this._CategoryID = value.CategoryID;
					}
					else
					{
						this._CategoryID = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("LocationCategory");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LocationCategory")]
	public partial class LocationCategory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _CategoryID;
		
		private System.Nullable<System.Guid> _ParentCategoryID;
		
		private string _Name;
		
		private System.Nullable<System.Guid> _UserID;
		
		private EntitySet<Location> _Locations;
		
		private EntitySet<LocationCategory> _LocationCategories;
		
		private EntityRef<LocationCategory> _LocationCategory1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCategoryIDChanging(System.Guid value);
    partial void OnCategoryIDChanged();
    partial void OnParentCategoryIDChanging(System.Nullable<System.Guid> value);
    partial void OnParentCategoryIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnUserIDChanging(System.Nullable<System.Guid> value);
    partial void OnUserIDChanged();
    #endregion
		
		public LocationCategory()
		{
			this._Locations = new EntitySet<Location>(new Action<Location>(this.attach_Locations), new Action<Location>(this.detach_Locations));
			this._LocationCategories = new EntitySet<LocationCategory>(new Action<LocationCategory>(this.attach_LocationCategories), new Action<LocationCategory>(this.detach_LocationCategories));
			this._LocationCategory1 = default(EntityRef<LocationCategory>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				if ((this._CategoryID != value))
				{
					this.OnCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._CategoryID = value;
					this.SendPropertyChanged("CategoryID");
					this.OnCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentCategoryID", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> ParentCategoryID
		{
			get
			{
				return this._ParentCategoryID;
			}
			set
			{
				if ((this._ParentCategoryID != value))
				{
					if (this._LocationCategory1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParentCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._ParentCategoryID = value;
					this.SendPropertyChanged("ParentCategoryID");
					this.OnParentCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LocationCategory_Location", Storage="_Locations", ThisKey="CategoryID", OtherKey="CategoryID")]
		public EntitySet<Location> Locations
		{
			get
			{
				return this._Locations;
			}
			set
			{
				this._Locations.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LocationCategory_LocationCategory", Storage="_LocationCategories", ThisKey="CategoryID", OtherKey="ParentCategoryID")]
		public EntitySet<LocationCategory> LocationCategories
		{
			get
			{
				return this._LocationCategories;
			}
			set
			{
				this._LocationCategories.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LocationCategory_LocationCategory", Storage="_LocationCategory1", ThisKey="ParentCategoryID", OtherKey="CategoryID", IsForeignKey=true)]
		public LocationCategory LocationCategory1
		{
			get
			{
				return this._LocationCategory1.Entity;
			}
			set
			{
				LocationCategory previousValue = this._LocationCategory1.Entity;
				if (((previousValue != value) 
							|| (this._LocationCategory1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LocationCategory1.Entity = null;
						previousValue.LocationCategories.Remove(this);
					}
					this._LocationCategory1.Entity = value;
					if ((value != null))
					{
						value.LocationCategories.Add(this);
						this._ParentCategoryID = value.CategoryID;
					}
					else
					{
						this._ParentCategoryID = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("LocationCategory1");
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
		
		private void attach_Locations(Location entity)
		{
			this.SendPropertyChanging();
			entity.LocationCategory = this;
		}
		
		private void detach_Locations(Location entity)
		{
			this.SendPropertyChanging();
			entity.LocationCategory = null;
		}
		
		private void attach_LocationCategories(LocationCategory entity)
		{
			this.SendPropertyChanging();
			entity.LocationCategory1 = this;
		}
		
		private void detach_LocationCategories(LocationCategory entity)
		{
			this.SendPropertyChanging();
			entity.LocationCategory1 = null;
		}
	}
}
#pragma warning restore 1591
