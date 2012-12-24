<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hospital_Detail.ascx.cs"
    Inherits="APPGISMS.UserControl.Hospital_Detail" %>
    
    <div class="GridViewTitleStyle" style="font-size:15px; padding-top:8px; width:412px;"><asp:Label ID="lbHospital_Name" runat="server" /></div> 
        <asp:DetailsView ID="dtlHospital" runat="server" AutoGenerateRows="False" CssClass="DetailsViewStyle" Style="width:412px;" >
            <FieldHeaderStyle CssClass="DetailsViewFieldHeaderStyle" Width="70"/>
            <RowStyle CssClass="DetailsViewRowStyle" />
            <AlternatingRowStyle CssClass="DetailsViewAlternatingRowStyle" />
            <HeaderStyle CssClass="DetailsViewHeaderStyle" />            
            <Fields>
                <asp:BoundField HeaderText="電　　話" DataField="HOSPITAL_TEL" 
                    ItemStyle-BackColor="White" >
                <ItemStyle BackColor="White" ></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="地　　址" DataField="HOSPITAL_ADDR"/>
                <asp:TemplateField HeaderText="語言能力" ItemStyle-BackColor="White" >
                    <ItemTemplate>
                        <asp:Image ID="imgChinese" runat="server" ImageUrl='<%# Bind("LANGUAGE_CHI") %>' />
                        <asp:Image ID="imgTaiwon_1" runat="server" ImageUrl='<%# Bind("LANGUAGE_TAN_1") %>' />
                        <asp:Image ID="imgTaiwon_2" runat="server" ImageUrl='<%# Bind("LANGUAGE_TAN_2") %>' />
                        <asp:Image ID="imgEnglish" runat="server" ImageUrl='<%# Bind("LANGUAGE_ENG") %>' />
                        <asp:Image ID="imgOther" runat="server" ImageUrl='<%# Bind("LANGUAGE_OTH") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>           
        </asp:DetailsView>
        <div style="height:26px; text-align:center; border-left:solid 2px #7B9623;border-right:solid 2px #7B9623;
           line-height:26px; border-top:solid 0px  #7B9623; border-bottom: solid 1px #7B9623; width:408px;
            background-color:#F0F4EC; color:#7B9623; font-size:13px; font-weight:bold; padding-top:8px;">院所門診時間 </div>
        <asp:GridView ID="gvHospitalTime" runat="server" AutoGenerateColumns="False" GridLines="Vertical"  
        CssClass="GridViewStyle" ShowFooter="True" OnRowCreated="gvHospitalTime_RowCreated" Style="width:412px;">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" Height="26px"  BackColor="White"/>
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
            <PagerStyle HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />            
            <FooterStyle CssClass="GridViewFooterStyle" Height="30px" BackColor="#F0F4EC" />
            <Columns>
                <asp:BoundField DataField="OPEN_TIME">
                    <ItemStyle HorizontalAlign="right" Width="30px"  Height="26px"  CssClass="GridViewFieldItemStyle" />                    
                </asp:BoundField>     
                <asp:TemplateField HeaderText="日" >
                    <ItemStyle HorizontalAlign="Center" Width="20px"  />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgSunday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("SUNDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="一">
                    <ItemStyle HorizontalAlign="Center" Width="20px"  />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgMonday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("MONDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="二">
                    <ItemStyle HorizontalAlign="Center" Width="20px"  />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgTuesday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("TUESDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="三">
                    <ItemStyle HorizontalAlign="Center" Width="20px"  />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgWednesday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("WEDNESDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="四">
                    <ItemStyle HorizontalAlign="Center" Width="20px"  />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgThursday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("THURSDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="五">
                    <ItemStyle HorizontalAlign="Center" Width="20px"  />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgFriday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("FRIDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="六">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgSaturday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("SATURDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="GridViewTitleStyle" style="height:26px; text-align:center; border-left:solid 2px #7B9623;border-right:solid 2px #7B9623;
           line-height:26px; border-top:solid 0px  #7B9623; border-bottom: solid 1px #7B9623; width:408px;
            background-color:#F0F4EC; color:#7B9623; font-size:13px; font-weight:bold; padding-top:8px;">
            門診醫師</div>
        <asp:UpdatePanel ID="upHospitalDoctor" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gvHospitalDoctor" runat="server" AutoGenerateColumns="False" 
                    GridLines="Vertical" EmptyDataText="無門診醫師" ShowFooter="True" AllowPaging="True"
                    CssClass="GridViewStyle" Style="width:412px;" OnPageIndexChanging="gvHospitalDoctor_PageIndexChanging"
                    OnRowCreated="gvHospitalDoctor_RowCreated"  
                    onrowcommand="gvHospitalDoctor_RowCommand" DataKeyNames="DOCTOR_SN" 
                    onrowdatabound="gvHospitalDoctor_RowDataBound">
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <RowStyle CssClass="GridViewRowStyle" Height="30px" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" Height="30px" />
                    <PagerStyle HorizontalAlign="Center" CssClass="GridViewPagerStyle"  BackColor="#F0F4EC"/>
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <FooterStyle CssClass="GridViewFooterStyle" Height="30px" />
                    <Columns>
                        <asp:BoundField DataField="DOCTOR_NAME" HeaderText="醫師姓名">
                         <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DOCTOR_SEX" HeaderText="性別">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="專長">
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        
                   <asp:TemplateField HeaderText="display" Visible="False">
                         <ItemTemplate>
                      <asp:Label ID="display" runat="server" Text='<%# Bind("DOCTOR_DISPLAY") %>'></asp:Label>
                         </ItemTemplate>
                   </asp:TemplateField>
                        
                  <asp:ButtonField Text="門診時間" HeaderText="門診時間" CommandName="Time">
                        <ItemStyle Width="70px" HorizontalAlign="Center" />
                   </asp:ButtonField>
                   
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>    
    <div class="GridViewTitleStyle" style="height:26px; text-align:center; border-left:solid 2px #7B9623;border-right:solid 2px #7B9623;
           line-height:26px; border-top:solid 0px  #7B9623; border-bottom: solid 0px #7B9623; width:408px;
            background-color:#F0F4EC; color:#7B9623; font-size:13px; font-weight:bold; padding-top:8px;">
            專案計畫</div>
        <asp:UpdatePanel ID="upProject" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="grvProject" runat="server" AutoGenerateColumns="False" Style="width:412px;"
                    GridLines="Vertical" EmptyDataText="無專案項目資料" ShowFooter="False" AllowPaging="True"
                    CssClass="GridViewStyle" DataKeyNames="HOSPITAL_SN">
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <RowStyle CssClass="GridViewRowStyle" Height="30px" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" Height="30px" />
                    <PagerStyle HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <FooterStyle CssClass="GridViewFooterStyle" Height="30px" />
                    <Columns>
                        <asp:BoundField DataField="PROJECT_TYPE" HeaderText="專案項目" >
                            <ItemStyle Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PROJECT_REMARK" HeaderText="服務醫師"/>
                   
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
   
    <br />
    <%--牙醫門診時間--%>
            <asp:HiddenField ID="hfDoctor_Time" runat="server" />
            <AjaxCTLToolkit:ModalPopupExtender ID="mpeDoctor_Time" runat="server" TargetControlID="hfDoctor_Time"
                PopupControlID="panTime_Dialog" CancelControlID="btnTime_Cancel" />
            <asp:Panel ID="panTime_Dialog" runat="server" Style="display:none">
                <AjaxCTLToolkit:RoundedCornersExtender ID="rceDoctor_Time" runat="server" TargetControlID="panTime_DialogWindow" 
                BorderColor="#7B9623" Radius="15" />
                <asp:Panel ID="panTime_DialogWindow" runat="server" Width="412px" 
                    CssClass="DialogWindow">
                    <div class="DialogTitle">牙醫師門診明細</div>
                    <asp:Panel ID="panTime_DialogContent" runat="server" Width="416px" 
                        Height="330px" CssClass="DialogContent" ScrollBars="Auto">
                        <asp:UpdatePanel ID="upTime_Dialog" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="DialogData" style="width: 100%">
                                 <asp:DetailsView ID="dlLanguageInfo_Doctor" runat="server" AutoGenerateRows="False" CssClass="DetailsViewStyle"
                                  Width="100%" Style=" width:412px;">
                                  <FieldHeaderStyle CssClass="DetailsViewFieldHeaderStyle" />
                                  <RowStyle CssClass="DetailsViewRowStyle" />
                                  <AlternatingRowStyle CssClass="DetailsViewAlternatingRowStyle" />
                                  <HeaderStyle CssClass="DetailsViewHeaderStyle" />
                                  <Fields>
                                    <asp:BoundField HeaderText="院所名稱" DataField="HOSPITAL_NAME" />
                                    <asp:BoundField HeaderText="電　　話" DataField="HOSPITAL_TEL" />
                                <asp:TemplateField HeaderText="語言能力">
                                 <ItemTemplate>
                                  <asp:Image ID="imgChinese" runat="server" ImageUrl='<%# Bind("LANGUAGE_CHI") %>' />
                                  <asp:Image ID="imgTaiwon_1" runat="server" ImageUrl='<%# Bind("LANGUAGE_TAN_1") %>' />
                                  <asp:Image ID="imgTaiwon_2" runat="server" ImageUrl='<%# Bind("LANGUAGE_TAN_2") %>' />
                                  <asp:Image ID="imgEnglish" runat="server" ImageUrl='<%# Bind("LANGUAGE_ENG") %>' />
                                  <asp:Image ID="imgOther" runat="server" ImageUrl='<%# Bind("LANGUAGE_OTH") %>' />
                                </ItemTemplate>
                                </asp:TemplateField>
                              </Fields>
                              </asp:DetailsView>
        <div class="GridViewTitleStyle" style="width: 412px">
        <asp:Label ID="lbDoctor_Name" runat="server" Font-Names="微軟正黑體"></asp:Label>
            醫師門診時間</div>
        <asp:GridView ID="grvTime_Doctor" runat="server" AutoGenerateColumns="False" Width="412"
            GridLines="Vertical" CssClass="GridViewStyle" ShowFooter="True" 
                                        onrowcreated="gvHospitalDoctorTime_RowCreated">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" Height="50px" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <EmptyDataRowStyle CssClass="GridViewEmptyDataRowStyle" />
            <PagerStyle HorizontalAlign="Center" CssClass="GridViewPagerStyle" />
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <FooterStyle CssClass="GridViewFooterStyle" Height="30px" />
            <Columns>
                <asp:BoundField DataField="OPEN_TIME">
                    <ItemStyle HorizontalAlign="Center" Width="30px" Height="30px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="日">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgSunday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("SUNDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="一">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgMonday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("MONDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="二">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgTuesday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("TUESDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="三">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgWednesday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("WEDNESDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="四">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgThursday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("THURSDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="五">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgFriday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("FRIDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="六">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Image ID="grv_imgSaturday" runat="server" ImageUrl="~/Images/Interface/OpenTime.png"
                            Visible='<%# Convert.ToBoolean(Eval("SATURDAY")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>   
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                
                                <asp:AsyncPostBackTrigger ControlID="gvHospitalDoctor" EventName="RowCommand" />
                                
                            </Triggers>
                        </asp:UpdatePanel>
                    </asp:Panel>
                    <div class="DialogButton">
                        <asp:Button ID="btnTime_Cancel" runat="server" Text="關閉" />
                    </div>
                </asp:Panel>
            </asp:Panel>

