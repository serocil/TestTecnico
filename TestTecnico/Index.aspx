<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TestTecnico.Index" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <section class="content-header">
        <h1 style="text-align: center">Colas</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                 <div class="box box-primary">
                      <div class="box-body">
                          <div class="form-group">
                              <label>Id</label>

                          </div>
                           <div class="form-group">
                               <asp:TextBox ID="txtId" CssClass="form-control" runat="server" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);"></asp:TextBox>
                           </div>
                      </div>
                </div>

            </div>
             <div class="col-md-6">
              <div class="box box-primary">
                      <div class="box-body">
                          <div class="form-group">
                              <label>Nombre</label>
                          </div>
                           <div class="form-group">
                               <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"  MaxLength="200"></asp:TextBox>
                           </div>
                      </div>
                </div>  
            </div>
            
        </div>
         </br>
         </br>
          <div class="row">
            <div class="col-xs-2 col-md-2">            
            </div>
            <div class="col-xs-2 col-md-2">      
               
            </div>
            <div class="col-xs-4 col-md-4">   
                 <button type="button" class="btn btn-info btn-insert" Width="100%">Guardar</button>
            </div>
            <div class="col-xs-4 col-md-4">   
                
            </div>
        </div>
         </br>
         </br>
         <div id="ListCola1" class='col-md-12' style="overflow: auto;">
         </div>
          </br>
         </br>
         <div id="ListCola2" class='col-md-12' style="overflow: auto;">
         </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
    <link rel="stylesheet" href="//cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" />
     <script src="js/cola.js"></script>
</asp:Content>
