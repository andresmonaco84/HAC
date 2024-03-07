using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using System.Windows.Forms;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Componentes
{
    public partial class FrmGestao : FrmBase
    {



        // Estoque de Movimentacao (CCusto)
        private ILocalEstoque _movimentacaoTipoCCusto;
        public ILocalEstoque EstoqueMovimentacao
        {
            get { return _movimentacaoTipoCCusto != null ? _movimentacaoTipoCCusto : _movimentacaoTipoCCusto = (ILocalEstoque)Global.Common.GetObject(typeof(ILocalEstoque)); }
        }

        //Movimento
        private IMovimentacao _movimento;
        public IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }

        // Material e medicamentos
        private IMaterialMedicamento _materialMedicamento;
        public IMaterialMedicamento MaterialMedicamento
        {
            get { return _materialMedicamento != null ? _materialMedicamento : _materialMedicamento = (IMaterialMedicamento)Global.Common.GetObject(typeof(IMaterialMedicamento)); }
        }


        // MatMedSetorConfig
        /// <summary>
        /// Carrega o estoque/filiais que que a unidade consome ou Quais unidades consomem desta unidade
        /// </summary>
        private SetorEstoqueConsumoDataTable dtbEstoqueConsumo;

        private MatMedSetorConfigDataTable dtbMatMedSetorConfig;
        private MatMedSetorConfigDTO dtoMatMedSetorConfig;
        private MatMedSetorConfigDTO dtoSetorCfg;

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }        


        public FrmGestao()
        {
            InitializeComponent();
        }
    }
}