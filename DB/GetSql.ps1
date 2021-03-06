param([int]$start_update_version=0)
process{
    
    if($start_update_version -eq 0){
        Write-Host "请输入起始数据库版本号";
        return ;
    }
    
    $basepath = Get-Location 
    
    $db_script_path = $basepath.ToString() + "\" + "upgradeformysql.xml";
    $xmldoc = New-Object "System.Xml.XmlDocument"
    $xmldoc.Load($db_script_path);
    $next_vserion = $start_update_version + 1;
    $versionXpath =[String]::Format( "DBUpgrade/UpgradeSql[@version>={0}]",$next_vserion);
    $upgradeSqlNodes = $xmldoc.SelectNodes($versionXpath);
    
    if($upgradeSqlNodes.Count -eq 0){
        Write-Host "没有脚本"
        return;
    }
    $version_sql_format = $xmldoc.SelectSingleNode("DBUpgrade/Settings/SettingSql").InnerText;
    #$updateSql = "";
    
    $updateSql = New-Object "System.Text.StringBuilder";
    
    foreach($updateSqlNode in $upgradeSqlNodes){
       $v= $updateSqlNode.GetAttribute("version");
       
       $node = $updateSqlNode.SelectSingleNode("Sql");
       $ref = $node.GetAttribute("ref");
       
       $sql = [String]::Empty;
       
       if([String]::IsNullOrEmpty($ref)){
            $sql = $updateSqlNode.SelectSingleNode("Sql").InnerText;
       }
       else{
         $refFilePath  = [System.IO.Path]::Combine($basepath,$ref);
         $sql = Get-Content -Path $refFilePath;
       }
       $tmp = $updateSql.AppendLine($sql);
       $tmp = $updateSql.AppendLine([String]::Format($version_sql_format,$start_update_version,$v));
    }
	 #write-output $updateSql.ToString() | out-file -filepath C:\sql.txt
     .\MyClipBoard.exe $updateSql.ToString();
    
    write "已经复制到时了剪贴版。" 
}