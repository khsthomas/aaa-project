﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:2.0.50727.3615
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace APPGISMS.DataSate {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("Membership_Trans_Statistics")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class Membership_Trans_Statistics : global::System.Data.DataSet {
        
        private TB_MS_TRANS_REPORTDataTable tableTB_MS_TRANS_REPORT;
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public Membership_Trans_Statistics() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected Membership_Trans_Statistics(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["TB_MS_TRANS_REPORT"] != null)) {
                    base.Tables.Add(new TB_MS_TRANS_REPORTDataTable(ds.Tables["TB_MS_TRANS_REPORT"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.Browsable(false)]
        [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public TB_MS_TRANS_REPORTDataTable TB_MS_TRANS_REPORT {
            get {
                return this.tableTB_MS_TRANS_REPORT;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.BrowsableAttribute(true)]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override global::System.Data.DataSet Clone() {
            Membership_Trans_Statistics cln = ((Membership_Trans_Statistics)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["TB_MS_TRANS_REPORT"] != null)) {
                    base.Tables.Add(new TB_MS_TRANS_REPORTDataTable(ds.Tables["TB_MS_TRANS_REPORT"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableTB_MS_TRANS_REPORT = ((TB_MS_TRANS_REPORTDataTable)(base.Tables["TB_MS_TRANS_REPORT"]));
            if ((initTable == true)) {
                if ((this.tableTB_MS_TRANS_REPORT != null)) {
                    this.tableTB_MS_TRANS_REPORT.InitVars();
                }
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "Membership_Trans_Statistics";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/Membership_Trans_Statistics.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableTB_MS_TRANS_REPORT = new TB_MS_TRANS_REPORTDataTable();
            base.Tables.Add(this.tableTB_MS_TRANS_REPORT);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeTB_MS_TRANS_REPORT() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            Membership_Trans_Statistics ds = new Membership_Trans_Statistics();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace)) {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length)) {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length) 
                                        && (s1.ReadByte() == s2.ReadByte())); ) {
                                ;
                            }
                            if ((s1.Position == s1.Length)) {
                                return type;
                            }
                        }
                    }
                }
                finally {
                    if ((s1 != null)) {
                        s1.Close();
                    }
                    if ((s2 != null)) {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }
        
        public delegate void TB_MS_TRANS_REPORTRowChangeEventHandler(object sender, TB_MS_TRANS_REPORTRowChangeEvent e);
        
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [global::System.Serializable()]
        [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class TB_MS_TRANS_REPORTDataTable : global::System.Data.TypedTableBase<TB_MS_TRANS_REPORTRow> {
            
            private global::System.Data.DataColumn columnCOUNTY_NAME;
            
            private global::System.Data.DataColumn columnTOWN_NAME;
            
            private global::System.Data.DataColumn columnNUM;
            
            private global::System.Data.DataColumn columnTRANS_STS;
            
            private global::System.Data.DataColumn columnTRANS_NUM;
            
            private global::System.Data.DataColumn columnCREATE_NUM;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public TB_MS_TRANS_REPORTDataTable() {
                this.TableName = "TB_MS_TRANS_REPORT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal TB_MS_TRANS_REPORTDataTable(global::System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected TB_MS_TRANS_REPORTDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn COUNTY_NAMEColumn {
                get {
                    return this.columnCOUNTY_NAME;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn TOWN_NAMEColumn {
                get {
                    return this.columnTOWN_NAME;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn NUMColumn {
                get {
                    return this.columnNUM;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn TRANS_STSColumn {
                get {
                    return this.columnTRANS_STS;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn TRANS_NUMColumn {
                get {
                    return this.columnTRANS_NUM;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn CREATE_NUMColumn {
                get {
                    return this.columnCREATE_NUM;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public TB_MS_TRANS_REPORTRow this[int index] {
                get {
                    return ((TB_MS_TRANS_REPORTRow)(this.Rows[index]));
                }
            }
            
            public event TB_MS_TRANS_REPORTRowChangeEventHandler TB_MS_TRANS_REPORTRowChanging;
            
            public event TB_MS_TRANS_REPORTRowChangeEventHandler TB_MS_TRANS_REPORTRowChanged;
            
            public event TB_MS_TRANS_REPORTRowChangeEventHandler TB_MS_TRANS_REPORTRowDeleting;
            
            public event TB_MS_TRANS_REPORTRowChangeEventHandler TB_MS_TRANS_REPORTRowDeleted;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddTB_MS_TRANS_REPORTRow(TB_MS_TRANS_REPORTRow row) {
                this.Rows.Add(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public TB_MS_TRANS_REPORTRow AddTB_MS_TRANS_REPORTRow(string COUNTY_NAME, string TOWN_NAME, string NUM, string TRANS_STS, string TRANS_NUM, string CREATE_NUM) {
                TB_MS_TRANS_REPORTRow rowTB_MS_TRANS_REPORTRow = ((TB_MS_TRANS_REPORTRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        COUNTY_NAME,
                        TOWN_NAME,
                        NUM,
                        TRANS_STS,
                        TRANS_NUM,
                        CREATE_NUM};
                rowTB_MS_TRANS_REPORTRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowTB_MS_TRANS_REPORTRow);
                return rowTB_MS_TRANS_REPORTRow;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override global::System.Data.DataTable Clone() {
                TB_MS_TRANS_REPORTDataTable cln = ((TB_MS_TRANS_REPORTDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataTable CreateInstance() {
                return new TB_MS_TRANS_REPORTDataTable();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnCOUNTY_NAME = base.Columns["COUNTY_NAME"];
                this.columnTOWN_NAME = base.Columns["TOWN_NAME"];
                this.columnNUM = base.Columns["NUM"];
                this.columnTRANS_STS = base.Columns["TRANS_STS"];
                this.columnTRANS_NUM = base.Columns["TRANS_NUM"];
                this.columnCREATE_NUM = base.Columns["CREATE_NUM"];
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnCOUNTY_NAME = new global::System.Data.DataColumn("COUNTY_NAME", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCOUNTY_NAME);
                this.columnTOWN_NAME = new global::System.Data.DataColumn("TOWN_NAME", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTOWN_NAME);
                this.columnNUM = new global::System.Data.DataColumn("NUM", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnNUM);
                this.columnTRANS_STS = new global::System.Data.DataColumn("TRANS_STS", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTRANS_STS);
                this.columnTRANS_NUM = new global::System.Data.DataColumn("TRANS_NUM", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnTRANS_NUM);
                this.columnCREATE_NUM = new global::System.Data.DataColumn("CREATE_NUM", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCREATE_NUM);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public TB_MS_TRANS_REPORTRow NewTB_MS_TRANS_REPORTRow() {
                return ((TB_MS_TRANS_REPORTRow)(this.NewRow()));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder) {
                return new TB_MS_TRANS_REPORTRow(builder);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Type GetRowType() {
                return typeof(TB_MS_TRANS_REPORTRow);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.TB_MS_TRANS_REPORTRowChanged != null)) {
                    this.TB_MS_TRANS_REPORTRowChanged(this, new TB_MS_TRANS_REPORTRowChangeEvent(((TB_MS_TRANS_REPORTRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.TB_MS_TRANS_REPORTRowChanging != null)) {
                    this.TB_MS_TRANS_REPORTRowChanging(this, new TB_MS_TRANS_REPORTRowChangeEvent(((TB_MS_TRANS_REPORTRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.TB_MS_TRANS_REPORTRowDeleted != null)) {
                    this.TB_MS_TRANS_REPORTRowDeleted(this, new TB_MS_TRANS_REPORTRowChangeEvent(((TB_MS_TRANS_REPORTRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.TB_MS_TRANS_REPORTRowDeleting != null)) {
                    this.TB_MS_TRANS_REPORTRowDeleting(this, new TB_MS_TRANS_REPORTRowChangeEvent(((TB_MS_TRANS_REPORTRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveTB_MS_TRANS_REPORTRow(TB_MS_TRANS_REPORTRow row) {
                this.Rows.Remove(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                Membership_Trans_Statistics ds = new Membership_Trans_Statistics();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "TB_MS_TRANS_REPORTDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace)) {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length)) {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length) 
                                            && (s1.ReadByte() == s2.ReadByte())); ) {
                                    ;
                                }
                                if ((s1.Position == s1.Length)) {
                                    return type;
                                }
                            }
                        }
                    }
                    finally {
                        if ((s1 != null)) {
                            s1.Close();
                        }
                        if ((s2 != null)) {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }
        
        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class TB_MS_TRANS_REPORTRow : global::System.Data.DataRow {
            
            private TB_MS_TRANS_REPORTDataTable tableTB_MS_TRANS_REPORT;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal TB_MS_TRANS_REPORTRow(global::System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableTB_MS_TRANS_REPORT = ((TB_MS_TRANS_REPORTDataTable)(this.Table));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string COUNTY_NAME {
                get {
                    try {
                        return ((string)(this[this.tableTB_MS_TRANS_REPORT.COUNTY_NAMEColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("資料表 \'TB_MS_TRANS_REPORT\' 中資料行 \'COUNTY_NAME\' 的值是 DBNull。", e);
                    }
                }
                set {
                    this[this.tableTB_MS_TRANS_REPORT.COUNTY_NAMEColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string TOWN_NAME {
                get {
                    try {
                        return ((string)(this[this.tableTB_MS_TRANS_REPORT.TOWN_NAMEColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("資料表 \'TB_MS_TRANS_REPORT\' 中資料行 \'TOWN_NAME\' 的值是 DBNull。", e);
                    }
                }
                set {
                    this[this.tableTB_MS_TRANS_REPORT.TOWN_NAMEColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string NUM {
                get {
                    try {
                        return ((string)(this[this.tableTB_MS_TRANS_REPORT.NUMColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("資料表 \'TB_MS_TRANS_REPORT\' 中資料行 \'NUM\' 的值是 DBNull。", e);
                    }
                }
                set {
                    this[this.tableTB_MS_TRANS_REPORT.NUMColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string TRANS_STS {
                get {
                    try {
                        return ((string)(this[this.tableTB_MS_TRANS_REPORT.TRANS_STSColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("資料表 \'TB_MS_TRANS_REPORT\' 中資料行 \'TRANS_STS\' 的值是 DBNull。", e);
                    }
                }
                set {
                    this[this.tableTB_MS_TRANS_REPORT.TRANS_STSColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string TRANS_NUM {
                get {
                    try {
                        return ((string)(this[this.tableTB_MS_TRANS_REPORT.TRANS_NUMColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("資料表 \'TB_MS_TRANS_REPORT\' 中資料行 \'TRANS_NUM\' 的值是 DBNull。", e);
                    }
                }
                set {
                    this[this.tableTB_MS_TRANS_REPORT.TRANS_NUMColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string CREATE_NUM {
                get {
                    try {
                        return ((string)(this[this.tableTB_MS_TRANS_REPORT.CREATE_NUMColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("資料表 \'TB_MS_TRANS_REPORT\' 中資料行 \'CREATE_NUM\' 的值是 DBNull。", e);
                    }
                }
                set {
                    this[this.tableTB_MS_TRANS_REPORT.CREATE_NUMColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCOUNTY_NAMENull() {
                return this.IsNull(this.tableTB_MS_TRANS_REPORT.COUNTY_NAMEColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCOUNTY_NAMENull() {
                this[this.tableTB_MS_TRANS_REPORT.COUNTY_NAMEColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsTOWN_NAMENull() {
                return this.IsNull(this.tableTB_MS_TRANS_REPORT.TOWN_NAMEColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetTOWN_NAMENull() {
                this[this.tableTB_MS_TRANS_REPORT.TOWN_NAMEColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsNUMNull() {
                return this.IsNull(this.tableTB_MS_TRANS_REPORT.NUMColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetNUMNull() {
                this[this.tableTB_MS_TRANS_REPORT.NUMColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsTRANS_STSNull() {
                return this.IsNull(this.tableTB_MS_TRANS_REPORT.TRANS_STSColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetTRANS_STSNull() {
                this[this.tableTB_MS_TRANS_REPORT.TRANS_STSColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsTRANS_NUMNull() {
                return this.IsNull(this.tableTB_MS_TRANS_REPORT.TRANS_NUMColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetTRANS_NUMNull() {
                this[this.tableTB_MS_TRANS_REPORT.TRANS_NUMColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCREATE_NUMNull() {
                return this.IsNull(this.tableTB_MS_TRANS_REPORT.CREATE_NUMColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCREATE_NUMNull() {
                this[this.tableTB_MS_TRANS_REPORT.CREATE_NUMColumn] = global::System.Convert.DBNull;
            }
        }
        
        /// <summary>
        ///Row event argument class
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class TB_MS_TRANS_REPORTRowChangeEvent : global::System.EventArgs {
            
            private TB_MS_TRANS_REPORTRow eventRow;
            
            private global::System.Data.DataRowAction eventAction;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public TB_MS_TRANS_REPORTRowChangeEvent(TB_MS_TRANS_REPORTRow row, global::System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public TB_MS_TRANS_REPORTRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591