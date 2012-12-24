<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Address_Info_Dialog.ascx.cs" Inherits="APPGISMS.DialogControl.Address_Info_Dialog" %>

<asp:Panel ID="panDialog" runat="server" Style="display: none;">
    <AjaxCTLToolkit:RoundedCornersExtender ID="rceDialogWindow" runat="server" TargetControlID="panDialogWindow" BorderColor="#7B9623" Radius="12" />
    <asp:Panel ID="panDialogWindow" runat="server" Width="570px" Height="300px" CssClass="DialogWindow">
        <asp:UpdatePanel ID="upDialog" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="DialogTitle">
                    <asp:Label ID="lbTitle" runat="server" Text="地址資訊" />
                </div>
                <asp:Panel ID="panDialogContent" runat="server" Height="220px" CssClass="DialogContent">
                    <div>
                        地址：<asp:Label ID="lbAddress_Info" runat="server"></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lbAddress_Detail1" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lbAddress_Detail2" runat="server" Visible="false"></asp:Label>
                        <table>
                            <tr>
                                <td rowspan="2">
                                    <asp:ListBox ID="lbxCounty" runat="server" AutoPostBack="true" Height="200px" Width="100px"
                                        DataTextField="COUNTY_NAME" DataValueField="COUNTY_NO" 
                                        onselectedindexchanged="lbxCounty_SelectedIndexChanged"></asp:ListBox>
                                </td>
                                <td rowspan="2">
                                    <asp:ListBox ID="lbxTown" runat="server" AutoPostBack="true" Enabled="false" Height="200px" Width="100px"
                                        DataTextField="TOWN_NAME" DataValueField="TOWN_NO" 
                                        onselectedindexchanged="lbxTown_SelectedIndexChanged"></asp:ListBox>
                                </td>
                                <td rowspan="2">
                                    <asp:ListBox ID="lbxRoad" runat="server" AutoPostBack="true" Enabled="false" Height="200px" Width="200px"
                                        DataTextField="ROAD_NAME" DataValueField="ROAD_NO" 
                                        onselectedindexchanged="lbxRoad_SelectedIndexChanged"></asp:ListBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnOne" runat="server" Text="１" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnTwo" runat="server" Text="２" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnThree" runat="server" Text="３" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnFour" runat="server" Text="４" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnFive" runat="server" Text="５" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnSix" runat="server" Text="６" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnSeven" runat="server" Text="７" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnEight" runat="server" Text="８" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnNine" runat="server" Text="９" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnTen" runat="server" Text="０" onclick="btnAddress_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnLane" runat="server" Text="巷" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnDash" runat="server" Text="之" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnNumber" runat="server" Text="號" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnAlley" runat="server" Text="弄" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnFloor" runat="server" Text="樓" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnRoom" runat="server" Text="室" onclick="btnAddress_Click" />
                                    <asp:Button ID="Button1" runat="server" Text="、" onclick="btnAddress_Click" />
                                    <asp:Button ID="btnBackspace" runat="server" Text="backspace" onclick="btnAddress_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel> 
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lbxCounty" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="lbxTown" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="DialogButton" style="text-align: center;">
            <asp:Button ID="btnChoose" runat="server" Text="確定" UseSubmitBehavior="False" onclick="btnChoose_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="取消" />
        </div>
    </asp:Panel>
</asp:Panel>
