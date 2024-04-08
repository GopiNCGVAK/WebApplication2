<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebApplication2.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h2>Products List</h2>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card">
                            <img src='<%# Eval("image") %>' class="card-img-top" alt="Product Image" style="max-width: 100px; height: 100px;" />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("title") %></h5>
                                <p class="card-text">Price: $<%# Eval("price") %></p>
                                <div class="form-group">
                                    <label for="quantity_<%# Container.ItemIndex %>">Quantity:</label>
                                    <input type="number" id="quantity_<%# Container.ItemIndex %>" class="form-control" value="1" min="1" />
                                </div>
                                <div class="btn-group mt-2" role="group">
                                    <button type="button" class="btn btn-primary mr-4" onclick="addToCart(<%# Container.ItemIndex %>)">Add to Cart</button>
                                    <button type="button" class="btn btn-success" onclick="buyNow(<%# Container.ItemIndex %>)">Buy Now</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <script>
        function addToCart(index) {
            var quantity = document.getElementById("quantity_" + index).value;
            // Add logic to add the product to the cart with the specified quantity
            console.log("Add to Cart clicked for product at index " + index + " with quantity " + quantity);
        }

        function buyNow(index) {
            var quantity = document.getElementById("quantity_" + index).value;
            // Add logic to directly proceed to checkout with the specified quantity
            console.log("Buy Now clicked for product at index " + index + " with quantity " + quantity);
        }
    </script>
</asp:Content>
