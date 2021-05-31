<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="CRUDWebFormVue.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

 
    <div id="app">
            <div  v-for="empleado in empleados.list" class="container"> 
                <div class="row"> 
                     <div class="col-6">
                         Nombre
                     </div>
                    <div class="col-6">
                        {{empleado.Nombres}}
                    </div>
                </div>
                <div class="row"> 
                     <div class="col-6">
                        Apellidos
                     </div>
                    <div class="col-6">
                        {{empleado.Apellidos}}
                    </div>
                </div>
            </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/vue@2/dist/vue.js"></script>
    <script src="/Scripts/utilities.js"></script>
    <script>
        var app = new Vue({
            el: '#app',
            data: {
                empleados: {
                    list:[]
                }
            },

            method: {
                getinfo: function () {
                    var self = this;

                    ajax2('Empleados.aspx/getempleados', null, null, function (response) {
                        self.empleados.list = response.empleados;
                      
                    });
                }
            }
        })
    </script>
</asp:Content>
