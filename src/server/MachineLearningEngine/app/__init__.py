from flask import Flask

def create_app():
    app = Flask(__name__)
    
    from .routes.greet_route import greet_bp
    app.register_blueprint(greet_bp, url_prefix='/api')
    return app