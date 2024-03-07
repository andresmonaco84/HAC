   function carregarPagina(strDiv) 
        {
            if (document.getElementById) 
            {  
            document.getElementById(strDiv).style.visibility = 'hidden';
            }
        }
        window.onload = carregarPagina('carregando');
