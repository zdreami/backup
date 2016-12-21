#include <io.h>			 // _findfirst() _findnext()
#include <windows.h>

#include<iostream>
#include <fstream>
#include <string>
#include<algorithm>
#include <ctime>

using namespace std;

//方法
void getlist();
int get_line(string FilePath);
void output(string listName,int filetype);
int list();
void sort();
//结构体
struct lines{
	string line;//存储信息
	int filetype;//信息种类,1->目录，2->书籍，3->歌曲，4->电影,5->软件，0->容错
}info[2000];
//全局变量
#define listlength 6
int typenum[listlength]={0};
string listName[listlength]={"容错","目录","书籍列表","歌曲列表","电影列表","软件列表"};
int n=0;
bool AscCompare(lines &tsa1,lines &tsa2)
{
	return strcmp(tsa1.line.c_str(),tsa2.line.c_str()) < 0 ? true : false;
}


int main()
{
	SetConsoleTitle(L"--列表--"); // 设置窗口标题
	printf("列表生成\n\n");
	getlist();
	printf("\n\n\n-。- By zdream\npress any key to continue");
	getchar();getchar();
	return 0;
}
void getlist()
{
	int thing;
	string FilePath;
	printf("请添加路径(可拖入文件夹至此)\n");
	cin>>FilePath;
	string::size_type pos=0; 
	if(FilePath.length()==1)
		FilePath+=":";
	while((pos=FilePath.find_first_of('\\',pos))!=string::npos)
	{  
		FilePath.insert(pos,"\\");//插入  
		pos=pos+2;
	}
	if(FilePath[FilePath.length()-1]!='\\')
		FilePath+="\\\\";
	thing=get_line(FilePath);
	if(thing!=-1)
	{
		std::sort(info,info + thing,AscCompare);//排序
		for(int i=2;i<listlength;i++){
			if(typenum[i]!=0){
				output(listName[i],i);
			}
		}
	}
	else
	{
		printf("路径错误,重新输入\n");
		getlist();
	}
}

int gettype(string name)
{
	string postfix;
	if(name.length()<5)
		return 0;
	postfix=name.substr(name.length()-3,3);
	transform(postfix.begin(), postfix.end(), postfix.begin(), ::tolower);//tolower小写，toupper大写
	//信息种类,1->目录，2->书籍，3->歌曲，4->电影,5->软件
	//文本:txt,pdf
	if(postfix=="txt"||postfix=="pdf")
		return 2;
	//音频:mp3,wav,flac,aac
	if(postfix=="mp3"||postfix=="wav"||postfix=="flac"||postfix=="aac")
		return 3;
	//视频:mkv,mp4
	if(postfix=="mkv"||postfix=="mp4")
		return 4;
	//安装软件:exe
	if(postfix=="exe")
		return 5;
	return 0;
}

int get_line(string FilePath)
{
	int filetype;
	long handle;                                    //用于查找的句柄
    struct _finddata_t fileinfo;                    //文件信息的结构体
    handle=_findfirst((FilePath+"*.*").c_str(),&fileinfo);         //第一次查找
	if(handle==-1)
		return -1;
	while(!_findnext(handle,&fileinfo))       //循环查找其他符合的文件直到找不到其他的为止
	{
		if(fileinfo.name[0]=='.')
			continue;
		if(fileinfo.attrib & _A_SUBDIR){
			string pathnow=FilePath+fileinfo.name+"\\\\";
			get_line(pathnow);
			continue;
		}
		if((filetype=gettype(fileinfo.name))!=0)//为扫描文件种类
		{
			info[n].line=fileinfo.name;		//存储
			info[n].filetype=filetype;
			typenum[filetype]++;
			n++;
		}
	}
	_findclose(handle);                             //关闭句柄
	return n-1;
}

void output(string listName,int filetype)
{
	int i=0;
	int same=0;
	string sameline[100];
	FILE *fp;
	fopen_s(&fp,(listName+".txt").c_str(), "w");//打开输出文件"a"他、后面添加，w删除重建
	fputs((listName+"\n").c_str(),fp);
	while(!info[i].line.empty())
	{
		if(info[i].filetype==filetype){
			info[i].line[info[i].line.length()-4]='\0';//去除后缀
			//fprintf(fp,"%d. ",num+1);
			info[i].line="\n"+info[i].line;
			if(info[i].line!=info[i-1].line)
				fputs(info[i].line.c_str(),fp);
			else{
				same++;
				sameline[same]=info[i].line;
			}
		}
		i++;
	}
	fprintf(fp,"\n\n\n数量:%d\n重复:%d\n",typenum[filetype],same);
	while(same){
		fputs(sameline[same].c_str(),fp);
		same--;
	}
	SYSTEMTIME st = {0};
	GetLocalTime(&st);
	fprintf(fp,"\n\n%d:%d %d/%d/%d",st.wHour,st.wMinute,st.wYear,st.wMonth,st.wDay);
	fclose(fp);
}


