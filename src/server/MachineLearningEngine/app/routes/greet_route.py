from flask import Blueprint, jsonify, request

greet_bp = Blueprint('greet', __name__)
@greet_bp.route('/greet', methods=['GET'])
def greet():
    name = request.args.get('name', 'World')
    greeting = f"Hello, {name}!"
    return jsonify({"greeting": greeting})