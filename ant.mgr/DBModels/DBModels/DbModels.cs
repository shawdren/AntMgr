using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AntData.ORM;
using AntData.ORM.Data;
using AntData.ORM.Linq;
using AntData.ORM.Mapping;

namespace DbModel
{
	/// <summary>
	/// Visx Version   : 3.3
	/// Github         : https://github.com/yuzd/AntData.ORM
	/// Database       : zant
	/// Data Source    : .
	/// Server Version : 14.00.1000
	/// </summary>
	public partial class AntEntity : IEntity
	{
		public IQueryable<SysCompany>       SysCompanies     { get { return this.Get<SysCompany>(); } }
		public IQueryable<SysIncident>      SysIncidents     { get { return this.Get<SysIncident>(); } }
		public IQueryable<SysProject>       SysProjects      { get { return this.Get<SysProject>(); } }
		public IQueryable<SysUser>          SysUsers         { get { return this.Get<SysUser>(); } }
		/// <summary>
		/// 系统菜单表
		/// </summary>
		public IQueryable<SystemMenu>       SystemMenu       { get { return this.Get<SystemMenu>(); } }
		/// <summary>
		/// 菜单按钮
		/// </summary>
		public IQueryable<SystemPageAction> SystemPageAction { get { return this.Get<SystemPageAction>(); } }
		/// <summary>
		/// 角色表
		/// </summary>
		public IQueryable<SystemRole>       SystemRole       { get { return this.Get<SystemRole>(); } }
		/// <summary>
		/// 后台系统用户表
		/// </summary>
		public IQueryable<SystemUsers>      SystemUsers      { get { return this.Get<SystemUsers>(); } }

		private readonly DataConnection con;

		public DataConnection DbContext
		{
			get { return this.con; }
		}

		public IQueryable<T> Get<T>()
			 where T : class
		{
			return this.con.GetTable<T>();
		}

		public AntEntity(DataConnection con)
		{
			this.con = con;
		}
	}

	[Table(Db="zant", Schema="dbo", Name="Sys_Company")]
	public partial class SysCompany : LinqToDBEntity
	{
		#region Column

		[Column("Tid",                DataType=AntData.ORM.DataType.Int32)   , PrimaryKey, Identity]
		public virtual int Tid { get; set; } // int

		/// <summary>
		/// 公司名称
		/// </summary>
		[Column("CompanyName",        DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="公司名称"), NotNull]
		public virtual string CompanyName { get; set; } // nvarchar(256)

		[Column("CreateTime",         DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? CreateTime { get; set; } // datetime

		[Column("Creator",            DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Creator { get; set; } // nvarchar(256)

		[Column("EditTime",           DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? EditTime { get; set; } // datetime

		[Column("Editor",             DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Editor { get; set; } // nvarchar(256)

		[Column("F1",                 DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F1 { get; set; } // nvarchar(256)

		[Column("F2",                 DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F2 { get; set; } // nvarchar(256)

		[Column("F3",                 DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F3 { get; set; } // nvarchar(256)

		[Column("Enabled",            DataType=AntData.ORM.DataType.Boolean) , NotNull]
		public virtual bool Enabled { get; set; } // bit

		[Column("DataChangeLastTime", DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? DataChangeLastTime { get; set; } // datetime

		#endregion
	}

	[Table(Db="zant", Schema="dbo", Name="Sys_Incident")]
	public partial class SysIncident : LinqToDBEntity
	{
		#region Column

		/// <summary>
		/// 主键
		/// </summary>
		[Column("ID",                  DataType=AntData.ORM.DataType.Guid,     Comment="主键"), PrimaryKey, NotNull]
		public virtual Guid ID { get; set; } // uniqueidentifier

		/// <summary>
		/// 项目Id
		/// </summary>
		[Column("ProjectId",           DataType=AntData.ORM.DataType.Guid,     Comment="项目Id"), NotNull]
		public virtual Guid ProjectId { get; set; } // uniqueidentifier

		/// <summary>
		/// 提出时间
		/// </summary>
		[Column("SubmitDate",          DataType=AntData.ORM.DataType.DateTime, Comment="提出时间"),    Nullable]
		public virtual DateTime? SubmitDate { get; set; } // datetime

		/// <summary>
		/// 事件描述
		/// </summary>
		[Column("IncidentDescription", DataType=AntData.ORM.DataType.NVarChar, Length=1000, Comment="事件描述"), NotNull]
		public virtual string IncidentDescription { get; set; } // nvarchar(1000)

		/// <summary>
		/// 状态
		/// </summary>
		[Column("Status",              DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="状态"),    Nullable]
		public virtual string Status { get; set; } // nvarchar(256)

		/// <summary>
		/// 提出人Id
		/// </summary>
		[Column("SubmitUserId",        DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="提出人Id"),    Nullable]
		public virtual string SubmitUserId { get; set; } // nvarchar(256)

		/// <summary>
		/// 解决人Id
		/// </summary>
		[Column("ResovledUserId",      DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="解决人Id"),    Nullable]
		public virtual string ResovledUserId { get; set; } // nvarchar(256)

		/// <summary>
		/// 提出时间
		/// </summary>
		[Column("ResovledDate",        DataType=AntData.ORM.DataType.DateTime, Comment="提出时间"),    Nullable]
		public virtual DateTime? ResovledDate { get; set; } // datetime

		/// <summary>
		/// 解决方法
		/// </summary>
		[Column("FixResulotion",       DataType=AntData.ORM.DataType.NVarChar, Length=1000, Comment="解决方法"),    Nullable]
		public virtual string FixResulotion { get; set; } // nvarchar(1000)

		[Column("CreateTime",          DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? CreateTime { get; set; } // datetime

		[Column("Creator",             DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Creator { get; set; } // nvarchar(256)

		[Column("EditTime",            DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? EditTime { get; set; } // datetime

		[Column("Editor",              DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Editor { get; set; } // nvarchar(256)

		[Column("F1",                  DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F1 { get; set; } // nvarchar(256)

		[Column("F2",                  DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F2 { get; set; } // nvarchar(256)

		[Column("F3",                  DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F3 { get; set; } // nvarchar(256)

		[Column("Enabled",             DataType=AntData.ORM.DataType.Boolean) , NotNull]
		public virtual bool Enabled { get; set; } // bit

		#endregion
	}

	[Table(Db="zant", Schema="dbo", Name="Sys_Project")]
	public partial class SysProject : LinqToDBEntity
	{
		#region Column

		/// <summary>
		/// 主键
		/// </summary>
		[Column("ID",               DataType=AntData.ORM.DataType.Guid,     Comment="主键"), PrimaryKey, NotNull]
		public virtual Guid ID { get; set; } // uniqueidentifier

		/// <summary>
		/// 公司Id
		/// </summary>
		[Column("CompanyId",        DataType=AntData.ORM.DataType.Guid,     Comment="公司Id"), NotNull]
		public virtual Guid CompanyId { get; set; } // uniqueidentifier

		/// <summary>
		/// 项目名称
		/// </summary>
		[Column("ProjectName",      DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="项目名称"),    Nullable]
		public virtual string ProjectName { get; set; } // nvarchar(256)

		/// <summary>
		/// 服务开始时间
		/// </summary>
		[Column("ServiceBeginDate", DataType=AntData.ORM.DataType.DateTime, Comment="服务开始时间"),    Nullable]
		public virtual DateTime? ServiceBeginDate { get; set; } // datetime

		/// <summary>
		/// 服务结束时间
		/// </summary>
		[Column("ServiceEndDate",   DataType=AntData.ORM.DataType.DateTime, Comment="服务结束时间"),    Nullable]
		public virtual DateTime? ServiceEndDate { get; set; } // datetime

		[Column("CreateTime",       DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? CreateTime { get; set; } // datetime

		[Column("Creator",          DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Creator { get; set; } // nvarchar(256)

		[Column("EditTime",         DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? EditTime { get; set; } // datetime

		[Column("Editor",           DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Editor { get; set; } // nvarchar(256)

		[Column("F1",               DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F1 { get; set; } // nvarchar(256)

		[Column("F2",               DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F2 { get; set; } // nvarchar(256)

		[Column("F3",               DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F3 { get; set; } // nvarchar(256)

		[Column("Enabled",          DataType=AntData.ORM.DataType.Boolean) , NotNull]
		public virtual bool Enabled { get; set; } // bit

		#endregion
	}

	[Table(Db="zant", Schema="dbo", Name="Sys_User")]
	public partial class SysUser : LinqToDBEntity
	{
		#region Column

		/// <summary>
		/// 主键
		/// </summary>
		[Column("ID",         DataType=AntData.ORM.DataType.Guid,     Comment="主键"), PrimaryKey, NotNull]
		public virtual Guid ID { get; set; } // uniqueidentifier

		/// <summary>
		/// 用户名
		/// </summary>
		[Column("UserId",     DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="用户名"), NotNull]
		public virtual string UserId { get; set; } // nvarchar(256)

		/// <summary>
		/// 真实姓名
		/// </summary>
		[Column("Name",       DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="真实姓名"), NotNull]
		public virtual string Name { get; set; } // nvarchar(256)

		/// <summary>
		/// 密码
		/// </summary>
		[Column("Password",   DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="密码"), NotNull]
		public virtual string Password { get; set; } // nvarchar(256)

		/// <summary>
		/// 类型
		/// </summary>
		[Column("Type",       DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="类型"), NotNull]
		public virtual string Type { get; set; } // nvarchar(256)

		/// <summary>
		/// 公司Id
		/// </summary>
		[Column("CompanyId",  DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="公司Id"), NotNull]
		public virtual string CompanyId { get; set; } // nvarchar(256)

		/// <summary>
		/// 电话
		/// </summary>
		[Column("Phone",      DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="电话"),    Nullable]
		public virtual string Phone { get; set; } // nvarchar(256)

		/// <summary>
		/// 邮件
		/// </summary>
		[Column("Email",      DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="邮件"),    Nullable]
		public virtual string Email { get; set; } // nvarchar(256)

		/// <summary>
		/// 微信
		/// </summary>
		[Column("Wechat",     DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="微信"),    Nullable]
		public virtual string Wechat { get; set; } // nvarchar(256)

		/// <summary>
		/// QQ
		/// </summary>
		[Column("QQ",         DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="QQ"),    Nullable]
		public virtual string QQ { get; set; } // nvarchar(256)

		/// <summary>
		/// 钉钉
		/// </summary>
		[Column("DingDingId", DataType=AntData.ORM.DataType.NVarChar, Length=256, Comment="钉钉"),    Nullable]
		public virtual string DingDingId { get; set; } // nvarchar(256)

		[Column("CreateTime", DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? CreateTime { get; set; } // datetime

		[Column("Creator",    DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Creator { get; set; } // nvarchar(256)

		[Column("EditTime",   DataType=AntData.ORM.DataType.DateTime),    Nullable]
		public virtual DateTime? EditTime { get; set; } // datetime

		[Column("Editor",     DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Editor { get; set; } // nvarchar(256)

		[Column("F1",         DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F1 { get; set; } // nvarchar(256)

		[Column("F2",         DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F2 { get; set; } // nvarchar(256)

		[Column("F3",         DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string F3 { get; set; } // nvarchar(256)

		[Column("Enabled",    DataType=AntData.ORM.DataType.Boolean) , NotNull]
		public virtual bool Enabled { get; set; } // bit

		#endregion
	}

	/// <summary>
	/// 系统菜单表
	/// </summary>
	[Table(Db="zant", Schema="dbo", Comment="系统菜单表", Name="system_menu")]
	public partial class SystemMenu : LinqToDBEntity
	{
		#region Column

		/// <summary>
		/// MenuId
		/// </summary>
		[Column("Tid",                DataType=AntData.ORM.DataType.Int64,    Comment="MenuId"), PrimaryKey, Identity]
		public virtual long Tid { get; set; } // bigint

		/// <summary>
		/// 最后更新时间
		/// </summary>
		[Column("DataChangeLastTime", DataType=AntData.ORM.DataType.DateTime, Comment="最后更新时间"), NotNull]
		public virtual DateTime DataChangeLastTime // datetime
		{
			get { return _DataChangeLastTime; }
			set { _DataChangeLastTime = value; }
		}

		/// <summary>
		/// 是否可用
		/// </summary>
		[Column("IsActive",           DataType=AntData.ORM.DataType.Boolean,  Comment="是否可用"), NotNull]
		public virtual bool IsActive { get; set; } // bit

		/// <summary>
		/// 父节点Id
		/// </summary>
		[Column("ParentTid",          DataType=AntData.ORM.DataType.Int64,    Comment="父节点Id"), NotNull]
		public virtual long ParentTid { get; set; } // bigint

		/// <summary>
		/// 名称
		/// </summary>
		[Column("Name",               DataType=AntData.ORM.DataType.NVarChar, Length=50, Comment="名称"),    Nullable]
		public virtual string Name { get; set; } // nvarchar(50)

		/// <summary>
		/// 展示的图标
		/// </summary>
		[Column("Ico",                DataType=AntData.ORM.DataType.NVarChar, Length=100, Comment="展示的图标"),    Nullable]
		public virtual string Ico { get; set; } // nvarchar(100)

		/// <summary>
		/// 连接地址
		/// </summary>
		[Column("Url",                DataType=AntData.ORM.DataType.NVarChar, Length=200, Comment="连接地址"),    Nullable]
		public virtual string Url { get; set; } // nvarchar(200)

		/// <summary>
		/// 排序
		/// </summary>
		[Column("OrderRule",          DataType=AntData.ORM.DataType.Int32,    Comment="排序"),    Nullable]
		public virtual int? OrderRule { get; set; } // int

		/// <summary>
		/// 等级
		/// </summary>
		[Column("Level",              DataType=AntData.ORM.DataType.Int32,    Comment="等级"),    Nullable]
		public virtual int? Level { get; set; } // int

		/// <summary>
		/// 样式
		/// </summary>
		[Column("Class",              DataType=AntData.ORM.DataType.NVarChar, Length=100, Comment="样式"),    Nullable]
		public virtual string Class { get; set; } // nvarchar(100)

		#endregion

		#region Field

		private DateTime _DataChangeLastTime = System.Data.SqlTypes.SqlDateTime.MinValue.Value;

		#endregion
	}

	/// <summary>
	/// 菜单按钮
	/// </summary>
	[Table(Db="zant", Schema="dbo", Comment="菜单按钮", Name="system_page_action")]
	public partial class SystemPageAction : LinqToDBEntity
	{
		#region Column

		/// <summary>
		/// 主键
		/// </summary>
		[Column("Tid",                DataType=AntData.ORM.DataType.Int64,    Comment="主键"), PrimaryKey, Identity]
		public virtual long Tid { get; set; } // bigint

		/// <summary>
		/// 最后更新时间
		/// </summary>
		[Column("DataChangeLastTime", DataType=AntData.ORM.DataType.DateTime, Comment="最后更新时间"), NotNull]
		public virtual DateTime DataChangeLastTime // datetime
		{
			get { return _DataChangeLastTime; }
			set { _DataChangeLastTime = value; }
		}

		/// <summary>
		/// 访问路径
		/// </summary>
		[Column("MenuTid",            DataType=AntData.ORM.DataType.Int64,    Comment="访问路径"), NotNull]
		public virtual long MenuTid { get; set; } // bigint

		/// <summary>
		/// ActionId
		/// </summary>
		[Column("ActionId",           DataType=AntData.ORM.DataType.NVarChar, Length=100, Comment="ActionId"),    Nullable]
		public virtual string ActionId { get; set; } // nvarchar(100)

		/// <summary>
		/// ActionName
		/// </summary>
		[Column("ActionName",         DataType=AntData.ORM.DataType.NVarChar, Length=255, Comment="ActionName"),    Nullable]
		public virtual string ActionName { get; set; } // nvarchar(255)

		/// <summary>
		/// ControlName
		/// </summary>
		[Column("ControlName",        DataType=AntData.ORM.DataType.NVarChar, Length=255, Comment="ControlName"),    Nullable]
		public virtual string ControlName { get; set; } // nvarchar(255)

		#endregion

		#region Field

		private DateTime _DataChangeLastTime = System.Data.SqlTypes.SqlDateTime.MinValue.Value;

		#endregion
	}

	/// <summary>
	/// 角色表
	/// </summary>
	[Table(Db="zant", Schema="dbo", Comment="角色表", Name="system_role")]
	public partial class SystemRole : LinqToDBEntity
	{
		#region Column

		/// <summary>
		/// 主键
		/// </summary>
		[Column("Tid",                DataType=AntData.ORM.DataType.Int64,    Comment="主键"), PrimaryKey, Identity]
		public virtual long Tid { get; set; } // bigint

		/// <summary>
		/// 最后更新时间
		/// </summary>
		[Column("DataChangeLastTime", DataType=AntData.ORM.DataType.DateTime, Comment="最后更新时间"), NotNull]
		public virtual DateTime DataChangeLastTime // datetime
		{
			get { return _DataChangeLastTime; }
			set { _DataChangeLastTime = value; }
		}

		/// <summary>
		/// 是否可用
		/// </summary>
		[Column("IsActive",           DataType=AntData.ORM.DataType.Boolean,  Comment="是否可用"), NotNull]
		public virtual bool IsActive { get; set; } // bit

		/// <summary>
		/// 菜单权限
		/// </summary>
		[Column("MenuRights",         DataType=AntData.ORM.DataType.NVarChar, Length=150, Comment="菜单权限"),    Nullable]
		public virtual string MenuRights { get; set; } // nvarchar(150)

		/// <summary>
		/// 按钮等权限
		/// </summary>
		[Column("ActionList",         DataType=AntData.ORM.DataType.NText,    Comment="按钮等权限"),    Nullable]
		public virtual string ActionList { get; set; } // ntext

		/// <summary>
		/// 创建者
		/// </summary>
		[Column("CreateUser",         DataType=AntData.ORM.DataType.NVarChar, Length=20, Comment="创建者"),    Nullable]
		public virtual string CreateUser { get; set; } // nvarchar(20)

		/// <summary>
		/// 创建者的角色Tid
		/// </summary>
		[Column("CreateRoleTid",      DataType=AntData.ORM.DataType.Int64,    Comment="创建者的角色Tid"), NotNull]
		public virtual long CreateRoleTid { get; set; } // bigint

		[Column("RoleName",           DataType=AntData.ORM.DataType.NVarChar, Length=150),    Nullable]
		public virtual string RoleName { get; set; } // nvarchar(150)

		[Column("Description",        DataType=AntData.ORM.DataType.NVarChar, Length=256),    Nullable]
		public virtual string Description { get; set; } // nvarchar(256)

		#endregion

		#region Field

		private DateTime _DataChangeLastTime = System.Data.SqlTypes.SqlDateTime.MinValue.Value;

		#endregion
	}

	/// <summary>
	/// 后台系统用户表
	/// </summary>
	[Table(Db="zant", Schema="dbo", Comment="后台系统用户表", Name="system_users")]
	public partial class SystemUsers : LinqToDBEntity
	{
		#region Column

		/// <summary>
		/// 主键
		/// </summary>
		[Column("Tid",                DataType=AntData.ORM.DataType.Int64,    Comment="主键"), PrimaryKey, Identity]
		public virtual long Tid { get; set; } // bigint

		/// <summary>
		/// 最后更新时间
		/// </summary>
		[Column("DataChangeLastTime", DataType=AntData.ORM.DataType.DateTime, Comment="最后更新时间"), NotNull]
		public virtual DateTime DataChangeLastTime // datetime
		{
			get { return _DataChangeLastTime; }
			set { _DataChangeLastTime = value; }
		}

		/// <summary>
		/// 是否可用
		/// </summary>
		[Column("IsActive",           DataType=AntData.ORM.DataType.Boolean,  Comment="是否可用"), NotNull]
		public virtual bool IsActive { get; set; } // bit

		/// <summary>
		/// 登陆名
		/// </summary>
		[Column("Eid",                DataType=AntData.ORM.DataType.NVarChar, Length=36, Comment="登陆名"),    Nullable]
		public virtual string Eid { get; set; } // nvarchar(36)

		/// <summary>
		/// 用户名
		/// </summary>
		[Column("UserName",           DataType=AntData.ORM.DataType.NVarChar, Length=50, Comment="用户名"),    Nullable]
		public virtual string UserName { get; set; } // nvarchar(50)

		/// <summary>
		/// 密码
		/// </summary>
		[Column("Pwd",                DataType=AntData.ORM.DataType.NVarChar, Length=50, Comment="密码"),    Nullable]
		public virtual string Pwd { get; set; } // nvarchar(50)

		/// <summary>
		/// 手机号
		/// </summary>
		[Column("Phone",              DataType=AntData.ORM.DataType.NVarChar, Length=20, Comment="手机号"),    Nullable]
		public virtual string Phone { get; set; } // nvarchar(20)

		/// <summary>
		/// 登陆IP
		/// </summary>
		[Column("LoginIp",            DataType=AntData.ORM.DataType.NVarChar, Length=30, Comment="登陆IP"),    Nullable]
		public virtual string LoginIp { get; set; } // nvarchar(30)

		/// <summary>
		/// 菜单权限
		/// </summary>
		[Column("MenuRights",         DataType=AntData.ORM.DataType.NVarChar, Length=150, Comment="菜单权限"),    Nullable]
		public virtual string MenuRights { get; set; } // nvarchar(150)

		/// <summary>
		/// 角色Tid(一个人只有一个角色)
		/// </summary>
		[Column("RoleTid",            DataType=AntData.ORM.DataType.Int64,    Comment="角色Tid(一个人只有一个角色)"), NotNull]
		public virtual long RoleTid { get; set; } // bigint

		/// <summary>
		/// 最后登录系统时间
		/// </summary>
		[Column("LastLoginTime",      DataType=AntData.ORM.DataType.DateTime, Comment="最后登录系统时间"),    Nullable]
		public virtual DateTime? LastLoginTime { get; set; } // datetime

		/// <summary>
		/// 登录的浏览器信息
		/// </summary>
		[Column("UserAgent",          DataType=AntData.ORM.DataType.NVarChar, Length=500, Comment="登录的浏览器信息"),    Nullable]
		public virtual string UserAgent { get; set; } // nvarchar(500)

		/// <summary>
		/// 创建的角色名称
		/// </summary>
		[Column("CreateRoleName",     DataType=AntData.ORM.DataType.NVarChar, Length=500, Comment="创建的角色名称"),    Nullable]
		public virtual string CreateRoleName { get; set; } // nvarchar(500)

		/// <summary>
		/// 创建者
		/// </summary>
		[Column("CreateUser",         DataType=AntData.ORM.DataType.NVarChar, Length=50, Comment="创建者"),    Nullable]
		public virtual string CreateUser { get; set; } // nvarchar(50)

		#endregion

		#region Field

		private DateTime _DataChangeLastTime = System.Data.SqlTypes.SqlDateTime.MinValue.Value;

		#endregion
	}

	public static partial class TableExtensions
	{
		public static SysCompany FindByBk(this IQueryable<SysCompany> table, int Tid)
		{
			return table.FirstOrDefault(t =>
				t.Tid == Tid);
		}

		public static async Task<SysCompany> FindByBkAsync(this IQueryable<SysCompany> table, int Tid)
		{
			return await table.FirstOrDefaultAsync(t =>
				t.Tid == Tid);
		}

		public static SysIncident FindByBk(this IQueryable<SysIncident> table, Guid ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static async Task<SysIncident> FindByBkAsync(this IQueryable<SysIncident> table, Guid ID)
		{
			return await table.FirstOrDefaultAsync(t =>
				t.ID == ID);
		}

		public static SysProject FindByBk(this IQueryable<SysProject> table, Guid ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static async Task<SysProject> FindByBkAsync(this IQueryable<SysProject> table, Guid ID)
		{
			return await table.FirstOrDefaultAsync(t =>
				t.ID == ID);
		}

		public static SysUser FindByBk(this IQueryable<SysUser> table, Guid ID)
		{
			return table.FirstOrDefault(t =>
				t.ID == ID);
		}

		public static async Task<SysUser> FindByBkAsync(this IQueryable<SysUser> table, Guid ID)
		{
			return await table.FirstOrDefaultAsync(t =>
				t.ID == ID);
		}

		public static SystemMenu FindByBk(this IQueryable<SystemMenu> table, long Tid)
		{
			return table.FirstOrDefault(t =>
				t.Tid == Tid);
		}

		public static async Task<SystemMenu> FindByBkAsync(this IQueryable<SystemMenu> table, long Tid)
		{
			return await table.FirstOrDefaultAsync(t =>
				t.Tid == Tid);
		}

		public static SystemPageAction FindByBk(this IQueryable<SystemPageAction> table, long Tid)
		{
			return table.FirstOrDefault(t =>
				t.Tid == Tid);
		}

		public static async Task<SystemPageAction> FindByBkAsync(this IQueryable<SystemPageAction> table, long Tid)
		{
			return await table.FirstOrDefaultAsync(t =>
				t.Tid == Tid);
		}

		public static SystemRole FindByBk(this IQueryable<SystemRole> table, long Tid)
		{
			return table.FirstOrDefault(t =>
				t.Tid == Tid);
		}

		public static async Task<SystemRole> FindByBkAsync(this IQueryable<SystemRole> table, long Tid)
		{
			return await table.FirstOrDefaultAsync(t =>
				t.Tid == Tid);
		}

		public static SystemUsers FindByBk(this IQueryable<SystemUsers> table, long Tid)
		{
			return table.FirstOrDefault(t =>
				t.Tid == Tid);
		}

		public static async Task<SystemUsers> FindByBkAsync(this IQueryable<SystemUsers> table, long Tid)
		{
			return await table.FirstOrDefaultAsync(t =>
				t.Tid == Tid);
		}
	}
}
