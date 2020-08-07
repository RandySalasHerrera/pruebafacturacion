using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.AspNetCore.Routing;

namespace EPublico.Core.Extensions
{
    public static class ObjectsExtensions
    {
        public static string GetValue(this Guid? g)
        {
            if (g == null)
                return null;

            return g.HasValue ? g.Value.ToString() : null;
        }

        public static void AddProperty(this ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }

        public static dynamic ToPersona<dynamic>(this dynamic obj)
        {

            Dictionary<string, object> persona = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                persona.Add("Id", dict["PersonaId"]);
                dict.Remove("PersonaId");

                persona.Add("Ruv", dict["Ruv"]);
                dict.Remove("Ruv");

                persona.Add("PrimerNombre", dict["PrimerNombre"]);
                dict.Remove("PrimerNombre");

                persona.Add("PrimerApellido", dict["PrimerApellido"]);
                dict.Remove("PrimerApellido");

                persona.Add("SegundoNombre", dict["SegundoNombre"]);
                dict.Remove("SegundoNombre");

                persona.Add("SegundoApellido", dict["SegundoApellido"]);
                dict.Remove("SegundoApellido");

                persona.Add("NombreCompleto", dict["NombreCompleto"]);
                dict.Remove("NombreCompleto");

                persona.Add("TipoIdentificacion", dict["TipoIdentificacionId"]);
                dict.Remove("TipoIdentificacionId");

                persona.Add("Identificacion", dict["Identificacion"]);
                dict.Remove("Identificacion");

                persona.Add("FechaExpedicion", dict["FechaExpedicion"]);
                dict.Remove("FechaExpedicion");

                persona.Add("FechaNacimiento", dict["FechaNacimiento"]);
                dict.Remove("FechaNacimiento");

                persona.Add("DepartamentoProcedencia", dict["DepartamentoProcedenciaId"]);
                dict.Remove("DepartamentoProcedenciaId");

                persona.Add("MunicipioProcedencia", dict["MunicipioProcedenciaId"]);
                dict.Remove("MunicipioProcedenciaId");

                persona.Add("Poblacion", dict["PoblacionId"]);
                dict.Remove("PoblacionId");

                persona.Add("Etnia", dict["EtniaId"]);
                dict.Remove("EtniaId");

                persona.Add("Sexo", dict["SexoId"]);
                dict.Remove("SexoId");

                persona.Add("IdentidadGenero", dict["IdentidadGeneroId"]);
                dict.Remove("IdentidadGeneroId");

                persona.Add("OrientacionSexual", dict["OrientacionSexualId"]);
                dict.Remove("OrientacionSexualId");

                persona.Add("TipoVendedor", dict["TipoVendedorId"]);
                dict.Remove("TipoVendedorId");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add persona property
                dynamicRoot.persona = DictionaryToObject(persona);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static dynamic ToEducacion<dynamic>(this dynamic obj)
        {
            Dictionary<string, object> educacion = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                educacion.Add("Id", dict["EducacionId"]);
                dict.Remove("EducacionId");

                educacion.Add("NivelEstudioId", dict["NivelEstudioId"]);
                dict.Remove("NivelEstudioId");

                educacion.Add("CabezaFamiliaId", dict["CabezaFamiliaId"]);
                dict.Remove("CabezaFamiliaId");

                educacion.Add("CapacitacionId", dict["CapacitacionId"]);
                dict.Remove("CapacitacionId");

                educacion.Add("JornadaCapacitacionId", dict["JornadaCapacitacionId"]);
                dict.Remove("JornadaCapacitacionId");

                educacion.Add("VinculoTrabajoPrivadoId", dict["VinculoTrabajoPrivadoId"]);
                dict.Remove("VinculoTrabajoPrivadoId");

                educacion.Add("DiaCapacitacionId", dict["DiaCapacitacionId"]);
                dict.Remove("DiaCapacitacionId");

                educacion.Add("VictimaConflictoArmadoId", dict["VictimaConflictoArmadoId"]);
                dict.Remove("VictimaConflictoArmadoId");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add educacion property
                dynamicRoot.educacion = DictionaryToObject(educacion);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static dynamic ToViviendaActual<dynamic>(this dynamic obj)
        {
            Dictionary<string, object> viviendaactual = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                viviendaactual.Add("Id", dict["ViviendaActualId"]);
                dict.Remove("ViviendaActualId");

                viviendaactual.Add("AreaId", dict["AreaId"]);
                dict.Remove("AreaId");

                viviendaactual.Add("CiudadId", dict["CiudadId"]);
                dict.Remove("CiudadId");

                viviendaactual.Add("DepartamentoId", dict["DepartamentoId"]);
                dict.Remove("DepartamentoId");

                viviendaactual.Add("Direccion", dict["Direccion"]);
                dict.Remove("Direccion");

                viviendaactual.Add("LocalidadId", dict["LocalidadId"]);
                dict.Remove("LocalidadId");

                viviendaactual.Add("UnidadComuneraId", dict["UnidadComuneraId"]);
                dict.Remove("UnidadComuneraId");

                viviendaactual.Add("BarrioId", dict["BarrioId"]);
                dict.Remove("BarrioId");

                viviendaactual.Add("EstratoSocioEconomicoId", dict["EstratoSocioEconomicoId"]);
                dict.Remove("EstratoSocioEconomicoId");

                viviendaactual.Add("TipoViviendaId", dict["TipoViviendaId"]);
                dict.Remove("TipoViviendaId");

                viviendaactual.Add("TelefonoResidencia", dict["TelefonoResidencia"]);
                dict.Remove("TelefonoResidencia");

                viviendaactual.Add("TelefonoMovil", dict["TelefonoMovil"]);
                dict.Remove("TelefonoMovil");

                viviendaactual.Add("CorreoElectronico", dict["CorreoElectronico"]);
                dict.Remove("CorreoElectronico");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add viviendaactualproperty
                dynamicRoot.viviendaactual = DictionaryToObject(viviendaactual);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static dynamic ToInformacionEconomica<dynamic>(this dynamic obj)
        {
            Dictionary<string, object> informacioneconomica = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                informacioneconomica.Add("Id", dict["InformacionEconomicaId"]);
                dict.Remove("InformacionEconomicaId");

                informacioneconomica.Add("OtrosProductos", dict["OtrosProductos"]);
                dict.Remove("OtrosProductos");

                informacioneconomica.Add("AlimentosPreparados", dict["AlimentosPreparados"]);
                dict.Remove("AlimentosPreparados");

                informacioneconomica.Add("Gastos", dict["Gastos"]);
                dict.Remove("Gastos");

                informacioneconomica.Add("ConcurrenciaGastoId", dict["ConcurrenciaGastoId"]);
                dict.Remove("ConcurrenciaGastoId");

                informacioneconomica.Add("FuenteFinanciacionId", dict["FuenteFinanciacionId"]);
                dict.Remove("FuenteFinanciacionId");

                informacioneconomica.Add("MaquinariaId", dict["MaquinariaId"]);
                dict.Remove("MaquinariaId");

                informacioneconomica.Add("DataCreditoId", dict["DataCreditoId"]);
                dict.Remove("DataCreditoId");

                informacioneconomica.Add("DiaTrabajado", dict["DiaTrabajado"]);
                dict.Remove("DiaTrabajado");

                informacioneconomica.Add("NumeroCarpas", dict["NumeroCarpas"]);
                dict.Remove("NumeroCarpas");

                informacioneconomica.Add("ConcurrenciaGastoMaquinariaId", dict["ConcurrenciaGastoMaquinariaId"]);
                dict.Remove("ConcurrenciaGastoMaquinariaId");

                informacioneconomica.Add("GastosMaquinaria", dict["GastosMaquinaria"]);
                dict.Remove("GastosMaquinaria");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add informacioneconomicaproperty
                dynamicRoot.informacioneconomica = DictionaryToObject(informacioneconomica);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static dynamic ToSeguridadSocial<dynamic>(this dynamic obj)
        {
            Dictionary<string, object> seguridadsocial = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                seguridadsocial.Add("Id", dict["SeguridadSocialId"]);
                dict.Remove("SeguridadSocialId");

                seguridadsocial.Add("AfiliadoSaludId", dict["AfiliadoSaludId"]);
                dict.Remove("AfiliadoSaludId");

                seguridadsocial.Add("RegimenSaludId", dict["RegimenSaludId"]);
                dict.Remove("RegimenSaludId");

                seguridadsocial.Add("PensionadoId", dict["PensionadoId"]);
                dict.Remove("PensionadoId");

                seguridadsocial.Add("CotizadoPensionId", dict["CotizadoPensionId"]);
                dict.Remove("CotizadoPensionId");

                seguridadsocial.Add("EpsId", dict["EpsId"]);
                dict.Remove("EpsId");

                seguridadsocial.Add("CondicionEspecialId", dict["CondicionEspecialId"]);
                dict.Remove("CondicionEspecialId");

                seguridadsocial.Add("CicloVitalId", dict["CicloVitalId"]);
                dict.Remove("CicloVitalId");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add informacioneconomicaproperty
                dynamicRoot.seguridadsocial = DictionaryToObject(seguridadsocial);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static dynamic ToInformacionNegocio<dynamic>(this dynamic obj)
        {
            Dictionary<string, object> informacionnegocio = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                informacionnegocio.Add("Id", dict["InformacionNegocioId"]);
                dict.Remove("InformacionNegocioId");

                informacionnegocio.Add("UbicacionTrabajoId", dict["UbicacionTrabajoId"]);
                dict.Remove("UbicacionTrabajoId");

                informacionnegocio.Add("DireccionNegocio", dict["DireccionNegocio"]);
                dict.Remove("DireccionNegocio");

                informacionnegocio.Add("BarrioNegocio", dict["BarrioNegocio"]);
                dict.Remove("BarrioNegocio");

                informacionnegocio.Add("LocalidadNegocio", dict["LocalidadNegocio"]);
                dict.Remove("LocalidadNegocio");

                informacionnegocio.Add("TiempoSurtidoId", dict["TiempoSurtidoId"]);
                dict.Remove("TiempoSurtidoId");

                informacionnegocio.Add("PromedioVentaDia", dict["PromedioVentaDia"]);
                dict.Remove("PromedioVentaDia");

                informacionnegocio.Add("PromedioIngresosMensuales", dict["PromedioIngresosMensuales"]);
                dict.Remove("PromedioIngresosMensuales");

                informacionnegocio.Add("MiembrosFamiliaVentaInformalesId", dict["MiembrosFamiliaVentaInformalesId"]);
                dict.Remove("MiembrosFamiliaVentaInformalesId");

                informacionnegocio.Add("CantidadMiembrosFamiliaVentaInformales", dict["CantidadMiembrosFamiliaVentaInformales"]);
                dict.Remove("CantidadMiembrosFamiliaVentaInformales");

                informacionnegocio.Add("FueraEspacioPublicoId", dict["FueraEspacioPublicoId"]);
                dict.Remove("FueraEspacioPublicoId");

                informacionnegocio.Add("ActividadCreacionNegocio", dict["ActividadCreacionNegocio"]);
                dict.Remove("ActividadCreacionNegocio");

                informacionnegocio.Add("CalleId", dict["CalleId"]);
                dict.Remove("CalleId");

                informacionnegocio.Add("TipoNegocioId", dict["TipoNegocioId"]);
                dict.Remove("TipoNegocioId");

                informacionnegocio.Add("TipologiaId", dict["TipologiaId"]);
                dict.Remove("TipologiaId");

                informacionnegocio.Add("TipoVentaId", dict["TipoVentaId"]);
                dict.Remove("TipoVentaId");

                informacionnegocio.Add("TipoOfertaId", dict["TipoOfertaId"]);
                dict.Remove("TipoOfertaId");

                informacionnegocio.Add("EspecificacionId", dict["EspecificacionId"]);
                dict.Remove("EspecificacionId");

                informacionnegocio.Add("LugarVentaMiembrosFamiliaVentaInformales", dict["LugarVentaMiembrosFamiliaVentaInformales"]);
                dict.Remove("LugarVentaMiembrosFamiliaVentaInformales");

                informacionnegocio.Add("OtraPreferenciaActividad", dict["OtraPreferenciaActividad"]);
                dict.Remove("OtraPreferenciaActividad");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add informacioneconomicaproperty
                dynamicRoot.informacionnegocio = DictionaryToObject(informacionnegocio);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static dynamic ToNucleoFamiliar<dynamic>(this dynamic obj)
        {
            Dictionary<string, object> nucleofamiliar = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                nucleofamiliar.Add("Id", dict["NucleoFamiliarId"]);
                dict.Remove("NucleoFamiliarId");

                nucleofamiliar.Add("PersonaMayorIngresoId", dict["PersonaMayorIngresoId"]);
                dict.Remove("PersonaMayorIngresoId");

                nucleofamiliar.Add("PorcentajeIngreso", dict["PorcentajeIngreso"]);
                dict.Remove("PorcentajeIngreso");

                nucleofamiliar.Add("ActividadRemuneradaId", dict["ActividadRemuneradaId"]);
                dict.Remove("ActividadRemuneradaId");

                nucleofamiliar.Add("EstadoCivilId", dict["EstadoCivilId"]);
                dict.Remove("EstadoCivilId");

                nucleofamiliar.Add("CantidadPersonasHogar", dict["CantidadPersonasHogar"]);
                dict.Remove("CantidadPersonasHogar");

                nucleofamiliar.Add("CantidadDependen", dict["CantidadDependen"]);
                dict.Remove("CantidadDependen");

                nucleofamiliar.Add("CantidadMenorDependen", dict["CantidadMenorDependen"]);
                dict.Remove("CantidadMenorDependen");

                nucleofamiliar.Add("CantidadMayorDependen", dict["CantidadMayorDependen"]);
                dict.Remove("CantidadMayorDependen");

                nucleofamiliar.Add("CantidadSinTrabajo", dict["CantidadSinTrabajo"]);
                dict.Remove("CantidadSinTrabajo");

                nucleofamiliar.Add("HijosId", dict["HijosId"]);
                dict.Remove("HijosId");

                nucleofamiliar.Add("CantidadHijos", dict["CantidadHijos"]);
                dict.Remove("CantidadHijos");

                nucleofamiliar.Add("EdadPrimerHijo", dict["EdadPrimerHijo"]);
                dict.Remove("EdadPrimerHijo");

                nucleofamiliar.Add("EdadMayorAporteHogar", dict["EdadMayorAporteHogar"]);
                dict.Remove("EdadMayorAporteHogar");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add informacioneconomicaproperty
                dynamicRoot.nucleofamiliar = DictionaryToObject(nucleofamiliar);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static dynamic ToAsociatividad<dynamic>(this dynamic obj)
        {
            Dictionary<string, object> asociatividad = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                asociatividad.Add("Id", dict["AsociatividadId"]);
                dict.Remove("AsociatividadId");

                asociatividad.Add("OrganizacionId", dict["OrganizacionId"]);
                dict.Remove("OrganizacionId");

                asociatividad.Add("TiempoOrganizacionId", dict["TiempoOrganizacionId"]);
                dict.Remove("TiempoOrganizacionId");

                asociatividad.Add("TipoOrganizacionId", dict["TipoOrganizacionId"]);
                dict.Remove("TipoOrganizacionId");

                asociatividad.Add("TipoRazonId", dict["TipoRazonId"]);
                dict.Remove("TipoRazonId");

                asociatividad.Add("DisposicionParticipacionId", dict["DisposicionParticipacionId"]);
                dict.Remove("DisposicionParticipacionId");

                asociatividad.Add("TieneDiscapacidadId", dict["TieneDiscapacidadId"]);
                dict.Remove("TieneDiscapacidadId");

                asociatividad.Add("DiscapacidadId", dict["DiscapacidadId"]);
                dict.Remove("DiscapacidadId");

                asociatividad.Add("AnioInicio", dict["AnioInicio"]);
                dict.Remove("AnioInicio");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add informacioneconomicaproperty
                dynamicRoot.asociatividad = DictionaryToObject(asociatividad);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static dynamic ToInformacionControl<dynamic>(this dynamic obj)
        {
            Dictionary<string, object> informacioncontrol = new Dictionary<string, object>();
            try
            {
                var dict = (IDictionary<string, object>)obj;

                if (dict == null)
                {
                    return default(dynamic);
                }

                informacioncontrol.Add("Id", dict["InformacionControlId"]);
                dict.Remove("InformacionControlId");

                informacioncontrol.Add("Lugar", dict["Lugar"]);
                dict.Remove("Lugar");

                informacioncontrol.Add("FechaDiligenciamiento", dict["FechaDiligenciamiento"]);
                dict.Remove("FechaDiligenciamiento");

                informacioncontrol.Add("NombreDiligenciamiento", dict["NombreDiligenciamiento"]);
                dict.Remove("NombreDiligenciamiento");

                informacioncontrol.Add("IdentificacionDiligenciamiento", dict["IdentificacionDiligenciamiento"]);
                dict.Remove("IdentificacionDiligenciamiento");

                // convert to dynamic
                var dynamicRoot = DictionaryToObject(dict);

                // add informacioneconomicaproperty
                dynamicRoot.informacioncontrol = DictionaryToObject(informacioncontrol);

                return dynamicRoot;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private static dynamic DictionaryToObject(IDictionary<String, Object> dictionary)
        {
            var expandoObj = new ExpandoObject();
            var expandoObjCollection = (ICollection<KeyValuePair<String, Object>>)expandoObj;

            foreach (var keyValuePair in dictionary)
            {
                expandoObjCollection.Add(keyValuePair);
            }
            dynamic eoDynamic = expandoObj;
            return eoDynamic;
        }
    }
}