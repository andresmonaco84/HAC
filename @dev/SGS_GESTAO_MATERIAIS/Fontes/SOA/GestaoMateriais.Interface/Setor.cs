using System.Data;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Interface
{
	public interface ISetor
	{
		SetorDataTable Sel(SetorDTO dto);

        ///<summary>
        /// Listar todos os setores que s�o abastecidos pelo centro de dispensa��o
        /// </summary>	
        SetorDataTable SelSetoresCentroDispensacao(SetorDTO dto);

        SetorDTO SelChave(SetorDTO dto);

        /// <summary>
        /// Obter almoxarifado central. Caso n�o exista, retorna null.
        /// </summary>
        SetorDTO SelAlmoxarifadoCentral();

        void Del(SetorDTO dto);		

        void Upd(SetorDTO dto);

        ///<summary>
        /// Atualiza o campo SubstituiAlmoxarifado
        /// </summary>
        void UpdSubstAlmox(SetorDTO dto);

		SetorDTO Ins(SetorDTO dto);

        ///<summary>
        /// Atualiza o Flag de Almoxarifado Central
        /// </summary>		
        void GravarAlmoxarifadoCentral(SetorDTO dtoSetor);

        ///<summary>
        /// Atualiza os setores que s�o abastecidos pelo centro de dispensa��o
        /// </summary>		
        void GravarSetoresCentroDispensacao(SetorDTO dtoSetorCentroDisp, SetorDataTable dtb);

        ///<summary>
        /// Atualiza o centro de dispensa��o do setor
        /// </summary>		
        void GravarCentroDispensacao(SetorDTO dtoSetor);

        SetorDataTable FiltrarSetor(SetorDataTable dtb, string filtroSql);

        void Salvar(SetorDTO dtoSetor);

        SetorDataTable SelSetoresCentroCusto(string centroCusto);
	}
}