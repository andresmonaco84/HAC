@echo off

cd GestaoMateriais

del *.pdb /s

echo Parando servicos em DEVHAC04
c:\windows\system32\sc.exe \\devhac04 stop SGS.GestaoMateriaisService

pause

echo Copiando arquivos GestaoMateriais
copy /y GestaoMateriais.Remoting.exe \\devhac04\Services\GestaoMateriais\
copy /y *.dll \\devhac04\Services\GestaoMateriais\

echo Reiniciando servicos em DEVHAC04 
c:\windows\system32\sc.exe \\devhac04 start SGS.GestaoMateriaisService
echo Pronto!!

pause

