#include <iostream>
#include <cstring>
#include <algorithm>
using namespace std;
typedef unsigned char Byte;
char digToChar(Byte d)
{if (d<10) return '0'+d;
 return 'A'-10+d;
}
Byte charToDig(char d)
{if (d<='9') return d-'0';
 return d-'A'+10;
}
class Num
{Byte base;
 Byte count,dig[256];
 public:
 Num(Byte b=10){base=b;count=1;*dig=0;}
 Num(Byte b,const char *d)
 {base=b;
  count=strlen(d);
  for (int i=count-1,j=0;i>=0;i--,j++)
   dig[j]=charToDig(d[i]);
 }
 Byte getCount()const{return count;}
 void setCount(Byte cnt){count=cnt;}
 Byte getDig(int n)const {return dig[n];}
 void setDig(int n,Byte d){dig[n]=d;}
 Num operator + (const Num &n) const
 {Num r(base);
  int i=0;
  Byte d,c=0;
  while (i<count || i<n.count)
  {d=c;
   if (i<count) d+=dig[i];
   if (i<n.count) d+=n.dig[i];
   if (d>=base) {c=1;d-=base;}
   else c=0;
   r.dig[i++]=d;
  }
  if (c) r.dig[i++]=c;
  r.count=i;
  return r;
 }
 Num operator *(Byte dg) const
 {Num r(base);
  int i=0,d;
  Byte c=0;
  while (i<count)
  {d=dg*dig[i]+c;
   c=d/base;
   r.dig[i++]=d%base;
  }
  if (c) r.dig[i++]=c;
  r.count=i;
  return r;
 }
 Num &operator +=(const Num &n)
 {*this=(*this + n);
  return *this;
 }
 Num operator *(const Num &n) const
 {Num r(base);
  for (int i=0;i<count;i++)
   {Num s=n*dig[i];
    memmove(&s.dig[i],s.dig,s.count);
    for (int j=0;j<i;j++) s.dig[j]=0;
    s.count+=i;
    r+=s;
   }
   return r;
 }
 Num &operator *=(const Num &n)
 {*this=(*this * n);
  return *this;
 }
};
ostream & operator<<(ostream &os,const Num &n)
{for (int i=n.getCount()-1;i>=0;i--) os<<digToChar(n.getDig(i));
 return os;
}
Num operator *(Byte dg,const Num &n)
{return n*dg;
}

//Globals
int p,n,k;
Byte d[128];
int c[128];

void inp()
{char t;
 cin>>p>>n>>k;
 for (int i=0;i<n;i++) {cin>>t;d[i]=charToDig(t);}
 for (int i=0;i<k;i++) cin>>c[i];
 sort(d,&d[n],greater<Byte>());
 sort(c,&c[k],less<int>());
}

void solve()
{Num *a=new Num[k];
 for (int i=0;i<k;i++)
 {a[i]=Num(p);
  a[i].setCount(c[i]);
  a[i].setDig(--c[i],d[i]);
 }
 int q=k;
 do
 {for (int i=k-1;i>=0;i--)
   if (c[i]>0) a[i].setDig(--c[i],d[q++]);
 }while (q<n);
 Num s(p,"1");
 for (int i=0;i<k;i++) s*=a[i];
 cout<<s<<endl;
 delete[] a;
}

int main()
{
 inp();
 sort(d,&d[n],greater<Byte>());
 solve();
 return 0;
}
