import 'package:eshop_admin/main.dart';
import 'package:eshop_admin/screens/product_detail_screen.dart';
import 'package:eshop_admin/screens/product_list_screen.dart';
import 'package:flutter/material.dart';

class MasterScreenWidget extends StatefulWidget {
  Widget? child;
  String? title;
  Widget? title_widget;
  MasterScreenWidget({this.title_widget,this.title,this.child,super.key});

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidget();
}

class _MasterScreenWidget extends State<MasterScreenWidget> {
  @override
  Widget build(BuildContext context) {
    return  Scaffold(
      appBar: AppBar(
        title: Text(widget.title??""),
      ),
      drawer: Drawer( 
      child:ListView
      (
        children: [ 
               ListTile(
            title: Text("Back"),
            onTap: (){
               Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => LoginPage(),
                          ));
            },
          ),
          ListTile(
            title: Text("Proizvodi"),
            onTap: (){
              Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => const ProductListScreen(),
                          ));
            },
          ),
          ListTile(
            title: Text("Detalji"),
            onTap: (){
              Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => const ProductDetailScreen(),
                          ));
            },
          ),
        ],
      ),
      ),
      body:widget.child!,
    );
  }
}