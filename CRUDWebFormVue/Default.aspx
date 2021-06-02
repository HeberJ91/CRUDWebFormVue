<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDWebFormVue._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  



 
    <div id="app" >


            <template>
              <div>
                <b-table striped hover :items="empleados.list" :fields="empleados.fields">
                       <template #cell(show_details)="row">
                        <b-button  class="btn btn-outline-primary  mr-2 ">
                          Details
                        </b-button>
                      </template>
                </b-table>
              </div>
            </template>

            <button class="btn btn-primary"  >Guardar</button>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/vue@2/dist/vue.js"></script>
    <script src="js/bootstrap-vue.min.js"></script>
    <script src="/Scripts/utilities.js"></script>
    <script>
        var app = new Vue({
            el: '#app',
            data: {
                empleados: {
                    fields: ["Id", "Nombres", "Apellidos", "show_details"],
                    list:[]
                }
            },
            created: function () {
                this.getinfo();
            },
            methods: {
                getinfo: function () {
                    var self = this;

                    ajax2('Default.aspx/getinfo', null, null, function (response) {
                        self.empleados.list = response.empleados;
                      
                    });
                }
            }
        })
    </script>
</asp:Content>
