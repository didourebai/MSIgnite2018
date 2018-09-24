using TravelGuideTunisia.Business.DTO;
using TravelGuideTunisia.Business.Models.Event;
using TravelGuideTunisia.Business.Models.EventRegistration;
using TravelGuideTunisia.Business.Models.Place;
using TravelGuideTunisia.Business.Models.SMSCheck;
using TravelGuideTunisia.Persistence.Entities.TravelGuide;

namespace TravelGuideTunisia.Business.Factories
{
    public class ModelFactory
    {
        //#region AnagraficaClienteResultModel

        //public static AnagraficaClienteResultModel ToAnagraficaClienteResultModel(AnagraficaClienti entity)
        //{
        //    return new AnagraficaClienteResultModel
        //    {
        //        ClienteCodice = entity.ClienteCodice,
        //        ClienteProgressivo = entity.ClienteProgressivo,
        //        ClienteIndirizzo = entity.ClienteIndirizzo,
        //        ClienteRagioneSociale = entity.ClienteRagioneSociale,
        //        ClienteCap = entity.ClienteCap,
        //        ClienteProvincia = entity.ClienteProvincia,
        //        ClienteCitta = entity.ClienteCitta,
        //        ClienteTelefono = entity.ClienteTelefono,
        //        ClienteFax = entity.ClienteFax,
        //        ClientePartitaIva = entity.ClientePartitaIva,
        //        ClienteCodiceFiscale = entity.ClienteCodiceFiscale,
        //        Rivenditore = entity.Rivenditore,
        //        SistemaUltimaModifica = entity.SistemaUltimaModifica,
        //    };
        //}
        public static CodeCheckRequestModel ConvertToCodeCheckInfoModel(CodeCheckInfoDTO codeCheckInfoDto)
        {
            if (codeCheckInfoDto == null)
                return null;
            return new CodeCheckRequestModel
            {
                AppId = codeCheckInfoDto.AppId,
                PhoneNumber = codeCheckInfoDto.PhoneNumber,
                UserId = codeCheckInfoDto.UserId,
                Code = codeCheckInfoDto.Code.ToString()
            };
        }
        //public static AnagraficaClienteResultModel ToAnagraficaClienteResultModel(ViewAnagraficaClienti entity)
        //{
        //    return new AnagraficaClienteResultModel
        //    {
        //        ClienteCodice = entity.ClienteCodice,
        //        ClienteProgressivo = entity.ClienteProgressivo,
        //        ClienteIndirizzo = entity.ClienteIndirizzo,
        //        ClienteRagioneSociale = entity.ClienteRagioneSociale,
        //        ClienteCap = entity.ClienteCap,
        //        ClienteProvincia = entity.ClienteProvincia,
        //        ClienteCitta = entity.ClienteCitta,
        //        ClienteTelefono = entity.ClienteTelefono,
        //        ClienteFax = entity.ClienteFax,
        //        ClientePartitaIva = entity.ClientePartitaIva,
        //        ClienteCodiceFiscale = entity.ClienteCodiceFiscale,
        //        Rivenditore = entity.Rivenditore,
        //        SistemaUltimaModifica = entity.SistemaUltimaModifica,
        //    };
        //}

        //public static AnagraficaClienteResultModel ToAnagraficaClienteResultModel(AnagraficaClientiBasic entity)
        //{
        //    return new AnagraficaClienteResultModel
        //    {
        //        ClienteCodice = entity.ClienteCodice,
        //        ClienteProgressivo = entity.ClienteProgressivo,
        //        ClienteIndirizzo = entity.ClienteIndirizzo,
        //        ClienteRagioneSociale = entity.ClienteRagioneSociale,
        //        ClienteCap = entity.ClienteCap,
        //        ClienteProvincia = entity.ClienteProvincia,
        //        ClienteCitta = entity.ClienteCitta,
        //        ClienteTelefono = entity.ClienteTelefono,
        //        ClienteFax = entity.ClienteFax,
        //        ClientePartitaIva = entity.ClientePartitaIva,
        //        ClienteCodiceFiscale = entity.ClienteCodiceFiscale,
        //        Rivenditore = entity.Rivenditore,
        //        SistemaUltimaModifica = entity.SistemaUltimaModifica,
        //    };
        //}

        //#endregion



        //#region AnagraficaClienteDetailsResultModel
        //public static AnagraficaClienteDetailsResultModel ToAnagraficaClienteDetailsResultModel(AnagraficaClienti entity)
        //{
        //    return new AnagraficaClienteDetailsResultModel
        //    {
        //        AgenteDefault1 = entity.AgenteDefault1,
        //        AgenteDefault2 = entity.AgenteDefault2,
        //        BancaAbi = entity.BancaAbi,
        //        BancaCab = entity.BancaCab,
        //        BancaCin = entity.BancaCin,
        //        BancaContoCorrente = entity.BancaContoCorrente,
        //        BancaIban = entity.BancaIban,
        //        CdcCircuito = entity.CdcCircuito,
        //        CdcNumber = entity.CdcNumber,
        //        CdcScadenza = entity.CdcScadenza,
        //        ClienteCap = entity.ClienteCap,
        //        ClienteCitta = entity.ClienteCitta,
        //        ClienteCodice = entity.ClienteCodice,
        //        ClienteCodiceFiscale = entity.ClienteCodiceFiscale,
        //        ClienteCodiceFornitore = entity.ClienteCodiceFornitore,
        //        ClienteCodiceNazione = entity.ClienteCodiceNazione,
        //        ClienteCodiceTipo = entity.ClienteCodiceTipo,
        //        ClienteCodiceTipoCategoria = entity.ClienteCodiceTipoCategoria,
        //        ClienteFax = entity.ClienteFax,
        //        ClienteIndirizzo = entity.ClienteIndirizzo,
        //        ClientePartitaIva = entity.ClientePartitaIva,
        //        ClienteProgressivo = entity.ClienteProgressivo,
        //        ClienteProvincia = entity.ClienteProvincia,
        //        ClienteRagioneSociale = entity.ClienteRagioneSociale,
        //        ClienteTelefono = entity.ClienteTelefono,
        //        CodiceSede = entity.CodiceSede,
        //        ContabilitaCodiceAnag0af = entity.ContabilitaCodiceAnag0af,
        //        ContabilitaDscFla0afAnag0af = entity.ContabilitaDscFla0afAnag0af,
        //        ContabilitaFla0afAnag0af = entity.ContabilitaFla0afAnag0af,
        //        Dimensione = entity.Dimensione,
        //        FatturaCap = entity.FatturaCap,
        //        FatturaCitta = entity.FatturaCitta,
        //        FatturaCodiceIva = entity.FatturaCodiceIva,
        //        FatturaCodiceNazione = entity.FatturaCodiceNazione,
        //        FatturaCodicePagamento = entity.FatturaCodicePagamento,
        //        FatturaIndirizzo = entity.FatturaIndirizzo,
        //        FatturaInvioEmail = entity.FatturaInvioEmail,
        //        FatturaInvioPostel = entity.FatturaInvioPostel,
        //        FatturaProvincia = entity.FatturaProvincia,
        //        FattureRagioneSociale = entity.FattureRagioneSociale,
        //        Filiale = entity.Filiale,
        //        IdentificativoFiscale = entity.IdentificativoFiscale,
        //        NascitaCitta = entity.NascitaCitta,
        //        NascitaData = entity.NascitaData,
        //        NascitaProvincia = entity.NascitaProvincia,
        //        OrdBlocco = entity.OrdBlocco,
        //        OrdCodiceListino = entity.OrdCodiceListino,
        //        OrdPriorita = entity.OrdPriorita,
        //        Pec = entity.Pec,
        //        PrivatoCognome = entity.PrivatoCognome,
        //        PrivatoNome = entity.PrivatoNome,
        //        RidCfSottoscrittore = entity.RidCfSottoscrittore,
        //        RidDataAutorizzazione = entity.RidDataAutorizzazione,
        //        RidDataEsito = entity.RidDataEsito,
        //        RidDescrizioneSottoscrittore = entity.RidDescrizioneSottoscrittore,
        //        RidEsito = entity.RidEsito,
        //        Rivenditore = entity.Rivenditore,
        //        SepaAperturaMandato = entity.SepaAperturaMandato,
        //        SepaChiusuraMandato = entity.SepaChiusuraMandato,
        //        SepaNumeroMandato = entity.SepaNumeroMandato,
        //        Sesso = entity.Sesso,
        //        Settore = entity.Settore,
        //        SistemaIdUtente = entity.SistemaIdUtente,
        //        SistemaStatusRegistrazione = entity.SistemaStatusRegistrazione,
        //        SistemaUltimaModifica = entity.SistemaUltimaModifica,
        //    };

        //}

        //public static AnagraficaClienteDetailsResultModel ToAnagraficaClienteDetailsResultModel(ViewAnagraficaClienti entity)
        //{
        //    return new AnagraficaClienteDetailsResultModel
        //    {
        //        AgenteDefault1 = entity.AgenteDefault1,
        //        AgenteDefault2 = entity.AgenteDefault2,
        //        BancaAbi = entity.BancaAbi,
        //        BancaCab = entity.BancaCab,
        //        BancaCin = entity.BancaCin,
        //        BancaContoCorrente = entity.BancaContoCorrente,
        //        BancaIban = entity.BancaIban,
        //        CdcCircuito = entity.CdcCircuito,
        //        CdcNumber = entity.CdcNumber,
        //        CdcScadenza = entity.CdcScadenza,
        //        ClienteCap = entity.ClienteCap,
        //        ClienteCitta = entity.ClienteCitta,
        //        ClienteCodice = entity.ClienteCodice,
        //        ClienteCodiceFiscale = entity.ClienteCodiceFiscale,
        //        ClienteCodiceFornitore = entity.ClienteCodiceFornitore,
        //        ClienteCodiceNazione = entity.ClienteCodiceNazione,
        //        ClienteCodiceTipo = entity.ClienteCodiceTipo,
        //        ClienteCodiceTipoCategoria = entity.ClienteCodiceTipoCategoria,
        //        ClienteFax = entity.ClienteFax,
        //        ClientePartitaIva = entity.ClientePartitaIva,
        //        ClienteProgressivo = entity.ClienteProgressivo,
        //        ClienteProvincia = entity.ClienteProvincia,
        //        ClienteRagioneSociale = entity.ClienteRagioneSociale,
        //        ClienteTelefono = entity.ClienteTelefono,
        //        CodiceSede = entity.CodiceSede,
        //        ContabilitaCodiceAnag0af = entity.ContabilitaCodiceAnag0af,
        //        ContabilitaDscFla0afAnag0af = entity.ContabilitaDscFla0afAnag0af,
        //        ContabilitaFla0afAnag0af = entity.ContabilitaFla0afAnag0af,
        //        Dimensione = entity.Dimensione,
        //        FatturaCap = entity.FatturaCap,
        //        FatturaCitta = entity.FatturaCitta,
        //        FatturaCodiceIva = entity.FatturaCodiceIva,
        //        FatturaCodiceNazione = entity.FatturaCodiceNazione,
        //        FatturaCodicePagamento = entity.FatturaCodicePagamento,
        //        FatturaIndirizzo = entity.FatturaIndirizzo,
        //        FatturaInvioEmail = entity.FatturaInvioEmail,
        //        FatturaInvioPostel = entity.FatturaInvioPostel,
        //        FatturaProvincia = entity.FatturaProvincia,
        //        FattureRagioneSociale = entity.FattureRagioneSociale,
        //        Filiale = entity.Filiale,
        //        IdentificativoFiscale = entity.IdentificativoFiscale,
        //        NascitaCitta = entity.NascitaCitta,
        //        NascitaData = entity.NascitaData,
        //        NascitaProvincia = entity.NascitaProvincia,
        //        OrdBlocco = entity.OrdBlocco,
        //        OrdCodiceListino = entity.OrdCodiceListino,
        //        OrdPriorita = entity.OrdPriorita,
        //        Pec = entity.Pec,
        //        PrivatoCognome = entity.PrivatoCognome,
        //        PrivatoNome = entity.PrivatoNome,
        //        RidCfSottoscrittore = entity.RidCfSottoscrittore,
        //        RidDataAutorizzazione = entity.RidDataAutorizzazione,
        //        RidDataEsito = entity.RidDataEsito,
        //        RidDescrizioneSottoscrittore = entity.RidDescrizioneSottoscrittore,
        //        RidEsito = entity.RidEsito,
        //        Rivenditore = entity.Rivenditore,
        //        SepaAperturaMandato = entity.SepaAperturaMandato,
        //        SepaChiusuraMandato = entity.SepaChiusuraMandato,
        //        SepaNumeroMandato = entity.SepaNumeroMandato,
        //        Sesso = entity.Sesso,
        //        Settore = entity.Settore,
        //        SistemaIdUtente = entity.SistemaIdUtente,
        //        SistemaStatusRegistrazione = entity.SistemaStatusRegistrazione,
        //        SistemaUltimaModifica = entity.SistemaUltimaModifica,
        //    };
        //}

        //public static AnagraficaClienteDetailsResultModel ToAnagraficaClienteDetailsResultModel(AnagraficaClientiBasic entity)
        //{
        //    return new AnagraficaClienteDetailsResultModel
        //    {
        //        AgenteDefault1 = entity.AgenteDefault1,
        //        AgenteDefault2 = entity.AgenteDefault2,
        //        BancaAbi = entity.BancaAbi,
        //        BancaCab = entity.BancaCab,
        //        BancaCin = entity.BancaCin,
        //        BancaContoCorrente = entity.BancaContoCorrente,
        //        BancaIban = entity.BancaIban,
        //        CdcCircuito = entity.CdcCircuito,
        //        CdcNumber = entity.CdcNumber,
        //        CdcScadenza = entity.CdcScadenza,
        //        ClienteCap = entity.ClienteCap,
        //        ClienteCitta = entity.ClienteCitta,
        //        ClienteCodice = entity.ClienteCodice,
        //        ClienteCodiceFiscale = entity.ClienteCodiceFiscale,
        //        ClienteCodiceFornitore = entity.ClienteCodiceFornitore,
        //        ClienteCodiceNazione = entity.ClienteCodiceNazione,
        //        ClienteCodiceTipo = entity.ClienteCodiceTipo,
        //        ClienteCodiceTipoCategoria = entity.ClienteCodiceTipoCategoria,
        //        ClienteFax = entity.ClienteFax,
        //        ClientePartitaIva = entity.ClientePartitaIva,
        //        ClienteProgressivo = entity.ClienteProgressivo,
        //        ClienteProvincia = entity.ClienteProvincia,
        //        ClienteRagioneSociale = entity.ClienteRagioneSociale,
        //        ClienteTelefono = entity.ClienteTelefono,
        //        CodiceSede = entity.CodiceSede,
        //        ContabilitaCodiceAnag0af = entity.ContabilitaCodiceAnag0af,
        //        ContabilitaDscFla0afAnag0af = entity.ContabilitaDscFla0afAnag0af,
        //        ContabilitaFla0afAnag0af = entity.ContabilitaFla0afAnag0af,
        //        Dimensione = entity.Dimensione,
        //        FatturaCap = entity.FatturaCap,
        //        FatturaCitta = entity.FatturaCitta,
        //        FatturaCodiceIva = entity.FatturaCodiceIva,
        //        FatturaCodiceNazione = entity.FatturaCodiceNazione,
        //        FatturaCodicePagamento = entity.FatturaCodicePagamento,
        //        FatturaIndirizzo = entity.FatturaIndirizzo,
        //        FatturaInvioEmail = entity.FatturaInvioEmail,
        //        FatturaInvioPostel = entity.FatturaInvioPostel,
        //        FatturaProvincia = entity.FatturaProvincia,
        //        FattureRagioneSociale = entity.FattureRagioneSociale,
        //        Filiale = entity.Filiale,
        //        IdentificativoFiscale = entity.IdentificativoFiscale,
        //        NascitaCitta = entity.NascitaCitta,
        //        NascitaData = entity.NascitaData,
        //        NascitaProvincia = entity.NascitaProvincia,
        //        OrdBlocco = entity.OrdBlocco,
        //        OrdCodiceListino = entity.OrdCodiceListino,
        //        OrdPriorita = entity.OrdPriorita,
        //        Pec = entity.Pec,
        //        PrivatoCognome = entity.PrivatoCognome,
        //        PrivatoNome = entity.PrivatoNome,
        //        RidCfSottoscrittore = entity.RidCfSottoscrittore,
        //        RidDataAutorizzazione = entity.RidDataAutorizzazione,
        //        RidDataEsito = entity.RidDataEsito,
        //        RidDescrizioneSottoscrittore = entity.RidDescrizioneSottoscrittore,
        //        RidEsito = entity.RidEsito,
        //        Rivenditore = entity.Rivenditore,
        //        SepaAperturaMandato = entity.SepaAperturaMandato,
        //        SepaChiusuraMandato = entity.SepaChiusuraMandato,
        //        SepaNumeroMandato = entity.SepaNumeroMandato,
        //        Sesso = entity.Sesso,
        //        Settore = entity.Settore,
        //        SistemaIdUtente = entity.SistemaIdUtente,
        //        SistemaStatusRegistrazione = entity.SistemaStatusRegistrazione,
        //        SistemaUltimaModifica = entity.SistemaUltimaModifica
        //    };
        //}
        //#endregion

        public static EventRegistrationResultModel ToEventRegistrationResultModel(EventRegistration eventRegistration)
        {
            return new EventRegistrationResultModel
            {
                EventTitle = eventRegistration?.Event?.Title,
                UserName = eventRegistration?.User.UserName
            };
        }

        public static PlaceResultModel ToPlaceResultModel(Place place)
        {
            return new PlaceResultModel
            {
                Governorate = place.Governorate,
                Address = place.Address,
                History = place.History,
                Id = place.Id,
                Descritpion = place.Descritpion
            };
        }

        public static EventResultModel ToEventResultModel(Event events)
        {
            return new EventResultModel
            {
                Id = events.Id,
                Descritpion = events.Descritpion,
                Title = events.Title,
                Address = events.Address,
                Governate = events.Governate,
                IsCancelled = events.IsCancelled,
                Date = events.Date
            };
        }
    }
}
