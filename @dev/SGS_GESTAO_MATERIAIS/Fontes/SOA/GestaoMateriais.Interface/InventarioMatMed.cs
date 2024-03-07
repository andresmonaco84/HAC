
using System;
using System.Text;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface IInventarioMatMed
	{
		InventarioMatMedDataTable Listar(InventarioMatMedDTO dto);

        InventarioMatMedDataTable ListarControle(InventarioMatMedDTO dto);

        void Excluir(InventarioMatMedDTO dto);

        void Gravar(InventarioMatMedDTO dto);

        void Gravar(InventarioMatMedDTO dto, string codBarraImport, int? qtdeImport);

        void AtivarInventario(InventarioMatMedDTO dto, bool apenasMateriaisEmGeral);

        void FecharInventario(InventarioMatMedDTO dto);

        void ExcluirArquivoSalvoImportacaoPalmTXT(InventarioMatMedDTO dto);

        void ExcluirItemLogImportacaoPalmTXT(InventarioMatMedDTO dto, string codBarraImport, int? qtdeImport);

        System.Data.DataTable ListarItensLogImportacaoPalmTXT(InventarioMatMedDTO dto);

        System.Data.DataTable ListarArquivosSalvosImportacaoPalmTXT(InventarioMatMedDTO dto);

        System.Data.DataTable ListarTXT(InventarioMatMedDTO dto);
        
        System.Data.DataTable SetoresSemContagem(DateTime dataDe, DateTime dataAte);

        DateTime? InventarioImportado(InventarioMatMedDTO dto);

        bool InventarioImportando(InventarioMatMedDTO dto, DateTime _dataInicioInv);

        void InserirHash(InventarioMatMedDTO dto, string hash);

        System.Data.DataTable ListarHashImportacaoPalmTXT(InventarioMatMedDTO dto, string hash);
	}
}