// ignore_for_file: prefer_const_literals_to_create_immutables

import 'package:eshop_admin/providers/product_provider.dart';
import 'package:eshop_admin/screens/product_detail_screen.dart';
import 'package:eshop_admin/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

class ProductListScreen extends StatefulWidget {
  const ProductListScreen({Key? key}) : super(key: key);

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  
  late ProductProvider _productProvider;

  //TextEditingController _ftsController = new TextEditingController();
  //TextEditingController _sifraController = new TextEditingController();

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _productProvider=context.read<ProductProvider>();

  }

  @override
  Widget build(BuildContext context) {
      return MasterScreenWidget(
      title: "Product list",
        child:Container(
        child: Column(children: [Text("Test"),
       ElevatedButton(
        onPressed:() async {
          print("login succeded");
          var data = await _productProvider.get();
          print("data: ${data['result'][0]['naziv']}");
         }, child: Text("Login")) ]),
    ),
    );
  }

 /* Widget _buildSearch() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Row(
        children: [
          Expanded(
            child: TextField(
              decoration: InputDecoration(labelText: "Naziv ili sifra"),
              controller: _ftsController,
            ),
          ),
          SizedBox(
            width: 8,
          ),
          Expanded(
            child: TextField(
              decoration: InputDecoration(labelText: "Šifra"),
              controller: _sifraController,
            ),
          ),
          ElevatedButton(
              onPressed: () async {
                print("login proceed");
                // Navigator.of(context).pop()

                // print("data: ${data.result[0].naziv}");
              },
              child: Text("Pretraga")),
          SizedBox(
            width: 8,
          ),

        ],
      ),
    );
  }*/

}