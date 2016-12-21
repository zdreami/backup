#include <io.h>			 // _findfirst() _findnext()
#include <windows.h>

#include<iostream>
#include <fstream>
#include <string>
#include<algorithm>
#include <ctime>

using namespace std;

//����
void getlist();
int get_line(string FilePath);
void output(string listName,int filetype);
int list();
void sort();
//�ṹ��
struct lines{
	string line;//�洢��Ϣ
	int filetype;//��Ϣ����,1->Ŀ¼��2->�鼮��3->������4->��Ӱ,5->�����0->�ݴ�
}info[2000];
//ȫ�ֱ���
#define listlength 6
int typenum[listlength]={0};
string listName[listlength]={"�ݴ�","Ŀ¼","�鼮�б�","�����б�","��Ӱ�б�","����б�"};
int n=0;
bool AscCompare(lines &tsa1,lines &tsa2)
{
	return strcmp(tsa1.line.c_str(),tsa2.line.c_str()) < 0 ? true : false;
}


int main()
{
	SetConsoleTitle(L"--�б�--"); // ���ô��ڱ���
	printf("�б�����\n\n");
	getlist();
	printf("\n\n\n-��- By zdream\npress any key to continue");
	getchar();getchar();
	return 0;
}
void getlist()
{
	int thing;
	string FilePath;
	printf("�����·��(�������ļ�������)\n");
	cin>>FilePath;
	string::size_type pos=0; 
	if(FilePath.length()==1)
		FilePath+=":";
	while((pos=FilePath.find_first_of('\\',pos))!=string::npos)
	{  
		FilePath.insert(pos,"\\");//����  
		pos=pos+2;
	}
	if(FilePath[FilePath.length()-1]!='\\')
		FilePath+="\\\\";
	thing=get_line(FilePath);
	if(thing!=-1)
	{
		std::sort(info,info + thing,AscCompare);//����
		for(int i=2;i<listlength;i++){
			if(typenum[i]!=0){
				output(listName[i],i);
			}
		}
	}
	else
	{
		printf("·������,��������\n");
		getlist();
	}
}

int gettype(string name)
{
	string postfix;
	if(name.length()<5)
		return 0;
	postfix=name.substr(name.length()-3,3);
	transform(postfix.begin(), postfix.end(), postfix.begin(), ::tolower);//tolowerСд��toupper��д
	//��Ϣ����,1->Ŀ¼��2->�鼮��3->������4->��Ӱ,5->���
	//�ı�:txt,pdf
	if(postfix=="txt"||postfix=="pdf")
		return 2;
	//��Ƶ:mp3,wav,flac,aac
	if(postfix=="mp3"||postfix=="wav"||postfix=="flac"||postfix=="aac")
		return 3;
	//��Ƶ:mkv,mp4
	if(postfix=="mkv"||postfix=="mp4")
		return 4;
	//��װ���:exe
	if(postfix=="exe")
		return 5;
	return 0;
}

int get_line(string FilePath)
{
	int filetype;
	long handle;                                    //���ڲ��ҵľ��
    struct _finddata_t fileinfo;                    //�ļ���Ϣ�Ľṹ��
    handle=_findfirst((FilePath+"*.*").c_str(),&fileinfo);         //��һ�β���
	if(handle==-1)
		return -1;
	while(!_findnext(handle,&fileinfo))       //ѭ�������������ϵ��ļ�ֱ���Ҳ���������Ϊֹ
	{
		if(fileinfo.name[0]=='.')
			continue;
		if(fileinfo.attrib & _A_SUBDIR){
			string pathnow=FilePath+fileinfo.name+"\\\\";
			get_line(pathnow);
			continue;
		}
		if((filetype=gettype(fileinfo.name))!=0)//Ϊɨ���ļ�����
		{
			info[n].line=fileinfo.name;		//�洢
			info[n].filetype=filetype;
			typenum[filetype]++;
			n++;
		}
	}
	_findclose(handle);                             //�رվ��
	return n-1;
}

void output(string listName,int filetype)
{
	int i=0;
	int same=0;
	string sameline[100];
	FILE *fp;
	fopen_s(&fp,(listName+".txt").c_str(), "w");//������ļ�"a"����������ӣ�wɾ���ؽ�
	fputs((listName+"\n").c_str(),fp);
	while(!info[i].line.empty())
	{
		if(info[i].filetype==filetype){
			info[i].line[info[i].line.length()-4]='\0';//ȥ����׺
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
	fprintf(fp,"\n\n\n����:%d\n�ظ�:%d\n",typenum[filetype],same);
	while(same){
		fputs(sameline[same].c_str(),fp);
		same--;
	}
	SYSTEMTIME st = {0};
	GetLocalTime(&st);
	fprintf(fp,"\n\n%d:%d %d/%d/%d",st.wHour,st.wMinute,st.wYear,st.wMonth,st.wDay);
	fclose(fp);
}


