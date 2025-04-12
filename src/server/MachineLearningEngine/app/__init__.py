from flask import Flask
from flask_cors import CORS
from .routes.property_route import property_bp

def create_app():
    app = Flask(__name__)
    CORS(app)  # Enable CORS for all routes
    app.register_blueprint(property_bp, url_prefix='/api')
    return app