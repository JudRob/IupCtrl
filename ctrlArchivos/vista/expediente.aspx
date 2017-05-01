<%@ Page Title="" Language="C#" MasterPageFile="../MasterPages/Menu.Master" AutoEventWireup="true" CodeBehind="expediente.aspx.cs" Inherits="ctrlArchivos.vista.archivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Forms.css" rel="stylesheet" type="text/css" />
    <script src="../JS/Alerts.js"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div id="contenido">
        <asp:Button ID="btnBuscar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Buscar" />
    &nbsp;<asp:Button ID="btnEliminar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Eliminar" />
    &nbsp;<asp:Button ID="btnActualizar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Actualizar" />

        <br />
             

        <asp:Label ID="lblBarraEstado" runat="server" Text="Bienvenido: escribe los datos que se indican del documento a registrar, el sistema generará automáticamente la clasificación"></asp:Label>
                 <br />
                 , REGISTRO DE CORRESPONDENCIA<br />
                 UN EXPEDIENTE ESTA FORMADO POR OFICIOS MEMORANDUMS TARJETAS , FACTURAS ETC.<br />
                 CONJUNTO DE EXPDIENTES ES UN ARCHIVO<br />
                 UNA CAJA ALMACENA EXPEDIENTES<br />
                 LOS ARCHIVOS SE CLASIFICAN POR AREA<br />
                 <br />
                 Para manejar la correspondencia se da de alta el expediente y se van agregando segun vayan llegando los documentos<br />
            <br />

        <div class="mysection">        
                   
            

            <asp:TextBox ID="TextBox1" class="form-control" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            <asp:TextBox ID="TextBox2" class="form-control" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            <asp:TextBox ID="TextBox3" class="form-control" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            <asp:TextBox ID="TextBox4" class="form-control" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            <asp:TextBox ID="TextBox5" class="form-control" runat="server" Enabled="False" Visible="False"></asp:TextBox>
            <br />

            <div class="mycontrol">
                Clasificación:
                <br />
                <asp:Label ID="lblclasexp" runat="server" Text="generandose..."></asp:Label>
            </div>

            <div class="mycontrol">
                Fondo:<br />
                <asp:DropDownList ID="ddlfondo" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlfondo_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="ddlidfondo" class="form-control" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </div>

            <div class="mycontrol">
                Sección:<br />
                <asp:DropDownList ID="ddlseccion" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlseccion_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="ddlidseccion" class="form-control" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            

            </div>

            <div class="mycontrol">
                Serie:<br />
                <asp:DropDownList ID="ddlserie" class="form-control" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                <br />
                <asp:DropDownList ID="ddlidserie" class="form-control" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </div>

            <div class="mycontrol">
                No. de expediente:<br />
                <asp:DropDownList ID="ddlnoexp" class="form-control" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            
            <div class="mycontrol">
                Año:<br />
                <asp:DropDownList ID="ddlaño" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>

        <div class="mysection">
            <div class="mycontrol">
                Unidad administrativa responsable:<br />
                <asp:DropDownList ID="ddluadmva" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
            
            <div class="mycontrol">
                Area, Depto. o Unidad Productora:<br />
                <asp:DropDownList ID="ddlsubuadmva" class="form-control" runat="server">
                </asp:DropDownList>
            </div>

             <div class="mycontrol">
                Nombre del responsable:<br />
                <asp:DropDownList ID="ddlcargoresp" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
            
            <div class="mycontrol">
                Resumen del contenido:<br />
                <asp:TextBox ID="TextBox6" runat="server"  class="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Asunto:<br />
                <asp:TextBox ID="TextBox7" runat="server" class="form-control"  TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Funcion:<br />
                <asp:RadioButton ID="RadioButton1" class="form-control"  runat="server" GroupName="funcion" Text="Sustantiva" />
                <asp:RadioButton ID="RadioButton2"  class="form-control" runat="server" GroupName="funcion" Text="Común" />
            </div>

            <div class="mycontrolLong">
                Acceso:<br />
                <asp:RadioButton ID="RadioButton3" class="form-control"  runat="server" Text="Público" GroupName="acceso" />
                <asp:RadioButton ID="RadioButton4"  class="form-control" runat="server" Text="Reservado" GroupName="acceso" />
                <asp:RadioButton ID="RadioButton5"  class="form-control" runat="server" Text="Confidencial" GroupName="acceso" />
            </div>

            <div class="mycontrolLong">
                Valores primarios:<br />
                <asp:RadioButton ID="RadioButton6"  class="form-control" runat="server" Text="Administrativo" GroupName="valprim" />
                <asp:RadioButton ID="RadioButton7"  class="form-control" runat="server" Text="Legal" GroupName="valprim" />
                <asp:RadioButton ID="RadioButton8"  class="form-control" runat="server" Text="Fiscal" GroupName="valprim" />
            </div>



        </div>



        <div class="mysection">
            <div class="mycontrol">
                Fechas extremas: del expediente (consulta&nbsp; a la bd de los doctos del expediente)<br />
                Inicial: la del documento mas antiguo del expediente<br />
                <asp:TextBox ID="TextBox8"  class="form-control" runat="server" TextMode="Date"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Final: la documento mas reciente del expediente<br />
                <asp:TextBox ID="TextBox9"  class="form-control" runat="server" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <div class="mysection">
            <div class="mycontrol">
                Numero de legajo:<br />
                <asp:TextBox ID="TextBox10"  class="form-control" runat="server" TextMode="Number"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Numero de fojas:<br />
                <asp:TextBox ID="TextBox11"  class="form-control" runat="server" TextMode="Number"></asp:TextBox>
            </div>

            <div class="mycontrolLong">
                Vinculacion con otro expediente: en caso de si cargar o habilitar text box o dropDownList relacion entre archivos<br />
                <asp:RadioButton ID="RadioButton14"  class="form-control" runat="server" Text="si" GroupName="vincotros" />
                <asp:RadioButton ID="RadioButton15"  class="form-control" runat="server" Text="no" GroupName="vincotros" />
                <asp:TextBox ID="TextBox12"  class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="myctrlXLong">
                Formato de soporte:<br />
                <asp:CheckBox ID="CheckBox1"  class="form-control" runat="server" Text="Papel" />
                
                <asp:CheckBox ID="CheckBox2"  class="form-control" runat="server" Text="Fotografía" />
                
                <asp:CheckBox ID="CheckBox3"  class="form-control" runat="server" Text="USB" />
                
                <asp:CheckBox ID="CheckBox4"  class="form-control" runat="server" Text="Disco" />
                
                <br />
                
                <asp:CheckBox ID="CheckBox5"  class="form-control" runat="server" Text="Otros(especificar):" />

                <asp:TextBox ID="TextBox13"  class="form-control" runat="server" Visible="False" ></asp:TextBox>
            </div>

            <div class="mycontrol">
                Plazo de conservación: *** en años son periodos manejar un dropDownList p.e. 1 año 2 años etc<br />
                <asp:TextBox ID="TextBox14"  class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mycontrol">
                 Tipo de expediente:<br />
                 <asp:RadioButton ID="RadioButton16"  class="form-control" runat="server" Text="Archivo de tramite" GroupName="tipexp" />
                 <asp:RadioButton ID="RadioButton17"  class="form-control" runat="server" Text="Archivo de concentración" GroupName="tipexp" />
            </div>

            <div class="mycontrol">
                Destino final:<br />
                <asp:RadioButton ID="RadioButton9"  class="form-control" runat="server" Text="Baja documental" GroupName="desfin" />
                <asp:RadioButton ID="RadioButton10"  class="form-control" runat="server" Text="Archivo histórico" GroupName="desfin" />
            </div>

            <div class="mycontrolLong">
                Valores secundarios:<br />
                <asp:RadioButton ID="RadioButton11"  class="form-control" runat="server" Text="valsec" GroupName="valsec" />
                <asp:RadioButton ID="RadioButton12"  class="form-control" runat="server" Text="valsec" GroupName="valsec" />
                <asp:RadioButton ID="RadioButton13"  class="form-control" runat="server" Text="valsec" GroupName="valsec" />
            </div>
        </div>

        <div class="mysection">
            <h2>Ubicación topográfica:(fisicamente donde esta ubicado)</h2>
            <div class="mycontrol">
                No. de edificio:<br />
                <asp:TextBox ID="TextBox15" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Nombre del edificio:<br />
                <asp:TextBox ID="TextBox16" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mycontrol">
                No. de pasillo:<br />
                <asp:TextBox ID="TextBox17" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mycontrol">
                No. de estante:<br />
                <asp:TextBox ID="TextBox18"  class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mycontrol">
                No. de charola:<br />
                <asp:TextBox ID="TextBox19"  class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Unidad de instalacion o numero de la caja:<br />
                <asp:DropDownList ID="DropDownList9"  class="form-control" runat="server">
                </asp:DropDownList>
            </div>
            
            <div class="mycontrol">
                    Domicilio de la oficina donde esta el archivo:<br />
                    <asp:TextBox ID="TextBox26"  class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mycontrol">
                Observaciones: (descripcion de la oficina en la que esta el archivo) p.e. Direccion de la ofician, piso, no de oficina o cubiculo, librero<br />
                <asp:TextBox ID="TextBox20" runat="server"  class="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>

        <div class="mysection">
            
            <h2>Datos Generales</h2>
            <div class="mysubsection">
                <h3>Lugar</h3>
                <div class="mycontrol">
                    Fecha:<br />
                    Puebla, Pue a:
                    <br />
                    <asp:TextBox ID="TextBox23" runat="server"  class="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="mycontrol">
                    Elaborado por:(quien captura)<br />
                    <asp:DropDownList ID="ddlrespCaptura"  class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="mysubsection">
                <h3>Jefe de área responsable del expediente </h3>

                <div class="mycontrol">
                    Nombre del responsable del expediente:
                    <br />
                    <asp:DropDownList ID="DropDownList11"  class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                
                <div class="mycontrol">
                    Cargo del responsable del expediente:<br />
                    <asp:DropDownList ID="DropDownList12"  class="form-control" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="mycontrol">
                    Telefono: <br />
                    <asp:TextBox ID="TextBox24"  class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mycontrol">
                    Correo electrónico:<br />
                    <asp:TextBox ID="TextBox25"  class="form-control" runat="server" TextMode="Email"></asp:TextBox>
                </div>

                <div class="mycontrol">
                    Area, Depto. o Unidad Productora: <br />
                    <asp:DropDownList ID="DropDownList13"  class="form-control" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="mycontrol">
                    Revisado y autorizado por:<br />
                    <asp:DropDownList ID="DropDownList14"  class="form-control" runat="server">
                    </asp:DropDownList>
                </div>

                
            </div>
        </div>

        <asp:Button ID="btnAgregar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />

    </div>
    
</asp:Content>