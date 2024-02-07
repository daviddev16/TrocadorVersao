using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

public partial class FrmPrincipal : Form
{
    public static readonly string ROOT_ALTERDATA = @"C:\Program Files (x86)\Alterdata";

    public struct ExecutavelShop
    {
        public readonly static ExecutavelShop VAZIO = new ExecutavelShop();
        
        public string DiretorioRaiz;
        public string Caminho;
        public string Versao;
        public bool Valido { get => !string.IsNullOrWhiteSpace(Versao); }
    }
    
    private string nomeExecutavelBase;
    private List<ExecutavelShop> executaveisShop;
    private ExecutavelShop executavelShopAtual;

    public FrmPrincipal()
    {
        nomeExecutavelBase = "wshop.exe";
        ReiniciarEstadoAplicacao();
        InitializeComponent();
    }

    private void FrmPrincipal_Load(object sender, EventArgs e)
    {
        IniciarInterface();
        cmbBxZShop.SelectedIndex = 0;
    }

    private void ReiniciarEstadoAplicacao()
    {
        if (executaveisShop != null)
            executaveisShop.Clear();
     
        executaveisShop = ObterMultiExecutaveisShop(ROOT_ALTERDATA);
        executavelShopAtual = ObterVersaoAtualShop(ROOT_ALTERDATA, nomeExecutavelBase);
    }

    private void IniciarInterface()
    {
        if (executavelShopAtual.Equals(ExecutavelShop.VAZIO))
        {
            MessageBox.Show("Não foi possível identificar o executável atual da pasta 'Shop'.");
            Application.Exit();
            return;
        }
        IniciarSeletorDeVersao(executaveisShop);
    }

    private void IniciarSeletorDeVersao(List<ExecutavelShop> executaveisShop)
    {
        cmbBxSelecaoVersao.Items.Clear();
        foreach (ExecutavelShop executavelShop in executaveisShop)
        {
            if (!executavelShopAtual.Versao.Equals(executavelShop.Versao))
            {
                cmbBxSelecaoVersao.Items.Add(executavelShop.Versao);
            }
        }
        cmbBxSelecaoVersao.SelectedIndex = 0;
    }

    private List<ExecutavelShop> ObterMultiExecutaveisShop(string rootPath)
    {
        List<ExecutavelShop> executaveisShop = new List<ExecutavelShop>();
        foreach (string shopDirPath in Directory.GetDirectories(rootPath, "Shop*", SearchOption.TopDirectoryOnly))
        {
            ExecutavelShop executavelShop = ObterExecutavelShop(shopDirPath, nomeExecutavelBase);
            executaveisShop.Add(executavelShop);
        }
        return executaveisShop;
    }

    private ExecutavelShop ObterExecutavelShop(string shopPath, string nomeExecutavel)
    {
        foreach (string caminhoExecutavelShop in Directory.GetFiles(shopPath, nomeExecutavel, SearchOption.TopDirectoryOnly))
        {
            ExecutavelShop executavelShop = new ExecutavelShop();
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(caminhoExecutavelShop);
            executavelShop.DiretorioRaiz = caminhoExecutavelShop;
            executavelShop.Caminho = caminhoExecutavelShop;
            executavelShop.Versao = fileVersion.FileVersion.Substring(0, 6).Replace(".", "");
            return executavelShop;
        }
        return ExecutavelShop.VAZIO;
    }

    private ExecutavelShop ObterVersaoAtualShop(string rootPath, string nomeExecutavel)
    {
        string shopAtualPath = Path.Combine(rootPath, "Shop");

        if (File.Exists(shopAtualPath))
            return ExecutavelShop.VAZIO;

        return ObterExecutavelShop(shopAtualPath, nomeExecutavel);
    }

    private ExecutavelShop ObterExecutavelSelecionado()
    {
        string versaoSelecionada = cmbBxSelecaoVersao.Text;
        if (!string.IsNullOrWhiteSpace(versaoSelecionada))
        {
            foreach (ExecutavelShop executavelShop in executaveisShop)
            {
                if (executavelShop.Versao.Equals(versaoSelecionada))
                {
                    return executavelShop;
                }
            }
        }
        return ExecutavelShop.VAZIO;
    }

    private void btnSelecionarVersao_Click(object sender, EventArgs e)
    {
        lsBxLog.Items.Clear();

        VerificarSeVersaoAtualEhValida();
        ExecutavelShop executavelShopDestino = ObterExecutavelSelecionado();
        
        RenomearPastas();
        Thread.Sleep(2000);
        RenomearPastas2(executavelShopDestino);
        Thread.Sleep(500);
        
        MessageBox.Show("Versão alterada.");
        
        ReiniciarEstadoAplicacao();
        IniciarInterface();
    }

    private string CaminhoFormatadoRoot(string relativoPath)
    {
        return Path.Combine(ROOT_ALTERDATA, relativoPath);
    }
    private void VerificarSeVersaoAtualEhValida()
    {
        if (executavelShopAtual.Equals(ExecutavelShop.VAZIO) || !executavelShopAtual.Valido)
        {
            MessageBox.Show("Não foi possível identificar o executável atual da pasta 'Shop'.");
            Application.Exit();
        }
    }

    private void RenomearPastas() 
    {

        string bibliotecaOrigemPath = CaminhoFormatadoRoot("Biblioteca");
        string shopOrigemPath = CaminhoFormatadoRoot("Shop");
        string modulosOrigemPath = CaminhoFormatadoRoot("Modulos");

        string bibliotecaDestinoPath = CaminhoFormatadoRoot("Biblioteca_" + executavelShopAtual.Versao);
        string shopDestinoPath = CaminhoFormatadoRoot("Shop_" + executavelShopAtual.Versao);
        string modulosDestinoPath = CaminhoFormatadoRoot("Modulos_" + executavelShopAtual.Versao);

        lsBxLog.Items.Add(NomeBonito(bibliotecaOrigemPath) + " para " + NomeBonito(bibliotecaDestinoPath));
        Directory.Move(bibliotecaOrigemPath, bibliotecaDestinoPath);

        lsBxLog.Items.Add(NomeBonito(shopOrigemPath) + " para " + NomeBonito(shopDestinoPath));
        Directory.Move(shopOrigemPath, shopDestinoPath);

        lsBxLog.Items.Add(NomeBonito(bibliotecaOrigemPath) + " para " + NomeBonito(bibliotecaDestinoPath));
        Directory.Move(modulosOrigemPath, modulosDestinoPath);

        Console.WriteLine("  ");
    }

    private void RenomearPastas2(ExecutavelShop executavelShopDestino)
    {
        string bibliotecaOrigemPath = CaminhoFormatadoRoot("Biblioteca_" + executavelShopDestino.Versao);
        string shopOrigemPath = CaminhoFormatadoRoot("Shop_" + executavelShopDestino.Versao);
        string modulosOrigemPath = CaminhoFormatadoRoot("Modulos_" + executavelShopDestino.Versao);

        string bibliotecaDestinoPath = CaminhoFormatadoRoot("Biblioteca");
        string shopDestinoPath = CaminhoFormatadoRoot("Shop");
        string modulosDestinoPath = CaminhoFormatadoRoot("Modulos");

        lsBxLog.Items.Add(NomeBonito(bibliotecaOrigemPath) + " para " + NomeBonito(bibliotecaDestinoPath));
        Directory.Move(bibliotecaOrigemPath, bibliotecaDestinoPath);

        lsBxLog.Items.Add(NomeBonito(shopOrigemPath) + " para " + NomeBonito(shopDestinoPath));
        Directory.Move(shopOrigemPath, shopDestinoPath);

        lsBxLog.Items.Add(NomeBonito(modulosOrigemPath) + " para " + NomeBonito(modulosDestinoPath));
        Directory.Move(modulosOrigemPath, modulosDestinoPath);

        Console.WriteLine("  ");
    }

    private string NomeBonito(string path)
    {
        return "\"Alterdata\\" + Path.GetFileName(path) + "\"";
    }

    private void cmbBxZShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        nomeExecutavelBase = cmbBxZShop.SelectedItem.ToString().Trim();
    }
}
