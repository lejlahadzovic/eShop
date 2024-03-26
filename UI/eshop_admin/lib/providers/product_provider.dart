import 'package:eshop_admin/utils/util.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart';

class ProductProvider with ChangeNotifier {
  static String? _baseUrl;
  String _endpoint ="Proizvod";

  ProductProvider(){
  _baseUrl=const String.fromEnvironment("baseUrl",defaultValue: "https://localhost:7134/");
  }

  Future<dynamic> get() async{
    var url = "$_baseUrl$_endpoint";
    var uri=Uri.parse(url);
    var headers=createHeaders();
    var response= await http.get(uri, headers: headers);

    if(isValidResponse(response)){
        var data=jsonDecode(response.body);
   
        return data; 
    }  else{
    throw new Exception("Unknown error.");
    }
    //print("response:${response.request},${response.statusCode}");
  

  }

bool isValidResponse(Response response){
  if(response.statusCode < 299){
    return true;
  } 
  else if(response.statusCode == 401){
    throw new Exception("Unauthorized");
  }
  else{
    throw new Exception("Please try again.");
}
}
  Map<String, String> createHeaders(){
    String username=Authorization.username??"";
    String password=Authorization.password??"";
    
    print("login $username $password");

    String basicAuth =
        "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };
    return headers;
  }
}